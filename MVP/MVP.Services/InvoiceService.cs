using MVP.Data.Enums;
using MVP.Services.DataModels;
using MVP.Services.Abstractions;
using MVP.Services.Factories;
using System;
using System.Threading.Tasks;
using Services.InvoiceBuilders;

namespace MVP.Services
{
    /// <summary>
    /// Invoice Service
    /// </summary>
    public class InvoiceService : IInvoiceService
    {
        private readonly IMessageFactory _messageFactory;

        private readonly IEmailService _emailService;

        private readonly IInvoiceBuilderFactory _invoiceBuilderFactory;

        public InvoiceService(
            IMessageFactory messageFactory,
            IEmailService emailService,
            IInvoiceBuilderFactory invoiceBuilderFactory)
        {
            _messageFactory = messageFactory;
            _emailService = emailService;
            _invoiceBuilderFactory = invoiceBuilderFactory;
        }

        /// <inheritdoc />
        public string CreateInvoice(InvoiceResponse response)
        {
            Message message = _messageFactory.Create(response);

            switch(response.InvoiceFormat)
            {
                case InvoiceFormat.JSON:
                    message.Builder = _invoiceBuilderFactory.Create<JsonInvoiceBuilder>();
                    break;
                case InvoiceFormat.HTML:
                    message.Builder = _invoiceBuilderFactory.Create<HtmlInvoiceBuilder>();
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
