using MVP.Data.Enums;
using MVP.Services.DataModels;
using MVP.Services.Abstractions;
using MVP.Services.Factories;
using System;

namespace MVP.Services
{
    /// <summary>
    /// Invoice Service
    /// </summary>
    public class InvoiceService : IInvoiceService
    {
        private readonly IMessageFactory _messageFactory;

        private readonly IInvoiceBuilderServiceFactory _invoiceBuilderServiceFactory;

        public InvoiceService(
            IMessageFactory messageFactory,
            IInvoiceBuilderServiceFactory invoiceBuilderServiceFactory)
        {
            _messageFactory = messageFactory;
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
    }
}
