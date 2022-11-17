using Data.Enums;
using Services.DataModels;
using System;
using System.Threading.Tasks;
using Services.Repositories;
using System.Collections.Generic;
using Data.Models;
using Services.Exceptions;
using System.Globalization;
using AutoMapper;
using System.Linq;

namespace Services
{
    /// <summary>
    /// Invoice Service
    /// </summary>
    public class InvoiceService : IInvoiceService
    {

        private readonly IInvoiceCreatorService _invoiceCreatorService;

        private readonly IInvoiceRepository _invoiceRepository;

        private readonly IMapper _mapper;

        public InvoiceService(
            IMapper mapper,
            IInvoiceRepository invoiceRepository,
            IInvoiceCreatorService invoiceCreatorService)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceCreatorService = invoiceCreatorService;
        }

        /// <inheritdoc />
        public async Task<List<HistoryResponse>> GetInvoicesAsync(HistoryRequest request)
        {
            if (request is null)
            {
                throw new NullReferenceException($"The '{nameof(request)}' is null");
            }

            DateTime start = await convertStringToDateTime(request.Start, nameof(request.Start));

            DateTime end = await convertStringToDateTime(request.End, nameof(request.End));

            if (start > end)
            {
                throw new ValidationException($"The '{nameof(request.Start)}' value must be lower then '{nameof(request.End)}' value!");
            }

            if (request.Skip < 0)
            {
                throw new ValidationException($"The '{nameof(request.Skip)}' must be 0 or greater!");
            }

            if (request.Take < 1)
            {
                throw new ValidationException($"The '{nameof(request.Take)}' must be at least 1!");
            }

            IEnumerable<Invoice> rawInvoices = await applyInvoiceFormatFilter(request, start, end);

            List<HistoryResponse> response = _mapper.Map<IEnumerable<Invoice>, IEnumerable<HistoryResponse>>(rawInvoices).ToList();

            return response;
        }

        /// <inheritdoc />
        public async Task<string> ManageInvoiceAsync(InvoiceResponse response)
        {
            return await _invoiceCreatorService.ManageInvoiceAsync(response);
        }

        private async Task<IEnumerable<Invoice>> applyInvoiceFormatFilter(HistoryRequest request, DateTime start, DateTime end)
        {
            IEnumerable<Invoice> rawInvoices = new List<Invoice>();

            if (request.InvoiceFormat != InvoiceFormat.Unknown)
            {
                rawInvoices = (await _invoiceRepository.GetInvoicesAsync(start, end, request.Skip, request.Take))
                    .Where(x => x.InvoiceFormat == request.InvoiceFormat);
            }
            else
            {
                rawInvoices = await _invoiceRepository.GetInvoicesAsync(start, end, request.Skip, request.Take);
            }

            return rawInvoices;
        }

        private async Task<DateTime> convertStringToDateTime(string date, string paramName)
        {
            try
            {
                return DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new ValidationException($"The '{paramName}' value is invalid!");
            }
        }

        
    }
}
