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
using Data;

namespace Services
{
    /// <summary>
    /// Invoice Service
    /// </summary>
    public class InvoiceService : IInvoiceService
    {

        private readonly IInvoiceManagerService _invoiceCreatorService;

        private readonly IInvoiceRepository _invoiceRepository;

        private readonly IMapper _mapper;

        public InvoiceService(
            IMapper mapper,
            IInvoiceRepository invoiceRepository,
            IInvoiceManagerService invoiceCreatorService)
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
                throw new NullReferenceException(Constants.GetString(Constants.NullreferenceException, nameof(request)));
            }

            DateTime start = await convertStringToDateTime(request.Start, nameof(request.Start));

            DateTime end = await convertStringToDateTime(request.End, nameof(request.End));

            if (start > end)
            {
                throw new ValidationException(Constants.GetString(Constants.TimelineValidation, nameof(request.Start),
                    nameof(request.End)));
            }

            if (request.Skip < 0)
            {
                throw new ValidationException(Constants.GetString(Constants.MustBePositive, nameof(request.Skip)));
            }

            if (request.Take < 1)
            {
                throw new ValidationException(Constants.GetString(Constants.MustBeAtLeastOne, nameof(request.Take)));
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
                return DateTime.ParseExact(date, Constants.TimeFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new ValidationException(Constants.GetString(Constants.InvalidDate, paramName));
            }
        }

        
    }
}
