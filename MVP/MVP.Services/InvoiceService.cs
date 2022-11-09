using MVP.Data.Enums;
using MVP.Services.DataModels;
using MVP.Services.Abstractions;
using MVP.Services.Factories;
using System;
using System.Threading.Tasks;

namespace MVP.Services
{
    /// <summary>
    /// Invoice Service
    /// </summary>
    public class InvoiceService : IInvoiceService
    {
        private readonly IMessageFactory _messageFactory;

        private readonly IEmailService _emailService;

        private readonly IInvoiceBuilderServiceFactory _invoiceBuilderServiceFactory;

        public InvoiceService(
            IMessageFactory messageFactory,
            IEmailService emailService,
            IInvoiceBuilderServiceFactory invoiceBuilderServiceFactory)
        {
            _messageFactory = messageFactory;
            _emailService = emailService;
            _invoiceBuilderServiceFactory = invoiceBuilderServiceFactory;
        }

        /// <inheritdoc />
        public string CreateInvoice(InvoiceResponse response)
        {
            Message message = _messageFactory.Create(response);

            switch(response.InvoiceFormat)
            {
                case InvoiceFormat.JSON:
                    message.Builder = _invoiceBuilderServiceFactory.Create<JsonInvoiceBuilderService>();
                    break;
                case InvoiceFormat.HTML:
                    message.Builder = _invoiceBuilderServiceFactory.Create<HtmlInvoiceBuilderService>();
                    break;
                default:
                    throw new Exception("Unexpected invoice format!");
            };

            return message.Build();
        }

        /// <inheritdoc />
        public void SendInvoiceViaEmail(string invoice, InvoiceResponse invoiceResponse)
        {
            if (invoiceResponse.SendEmail)
            {
                Task.Run(() => _emailService.SendMail(invoice, invoiceResponse.EmailAddress));
            }
        }
    }
}
