using Data;
using Data.Enums;
using Services.Abstractions;
using Services.DataModels;
using Services.Factories;
using Services.InvoiceBuilders;
using Services.Repositories;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class InvoiceManagerService : IInvoiceManagerService
    {
        private readonly IMessageFactory _messageFactory;

        private readonly IEmailService _emailService;

        private readonly IInvoiceRepository _invoiceRepository;

        private readonly IInvoiceBuilderFactory _invoiceBuilderFactory;

        public InvoiceManagerService(
            IMessageFactory messageFactory,
            IEmailService emailService,
            IInvoiceRepository invoiceRepository,
            IInvoiceBuilderFactory invoiceBuilderFactory)
        {
            _messageFactory = messageFactory;
            _emailService = emailService;
            _invoiceRepository = invoiceRepository;
            _invoiceBuilderFactory = invoiceBuilderFactory;
        }

        /// <inheritdoc />
        public async Task<string> ManageInvoiceAsync(InvoiceResponse response)
        {
            string invoice = await createInvoice(response);

            Task saveInvoiceTask = _invoiceRepository.AddAsync(response.InvoiceFormat, invoice);
            Task sendEmailTask = sendInvoiceViaEmailAsync(invoice, response);

            await saveInvoiceTask;
            await sendEmailTask;

            return invoice;
        }

        private async Task<string> createInvoice(InvoiceResponse response)
        {
            Message message = _messageFactory.Create(response);

            switch (response.InvoiceFormat)
            {
                case InvoiceFormat.JSON:
                    message.Builder = _invoiceBuilderFactory.Create<JsonInvoiceBuilder>();
                    break;
                case InvoiceFormat.HTML:
                    message.Builder = _invoiceBuilderFactory.Create<HtmlInvoiceBuilder>();
                    break;
                default:
                    throw new Exception(Constants.InvalidInvoiceFormat);
            };

            return await message.BuildAsync();
        }

        private async Task sendInvoiceViaEmailAsync(string invoice, InvoiceResponse invoiceResponse)
        {
            if (invoiceResponse.SendEmail)
            {
                await Task.Run(() => _emailService.SendMail(invoice, invoiceResponse.EmailAddress));
            }
        }
    }
}
