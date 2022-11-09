using MVP.Services.DataModels;
using Services.InvoiceBuilders;

namespace MVP.Services.Abstractions
{
    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public abstract class Message
    {
        /// <summary>
        /// Invoice Data
        /// </summary>
        public InvoiceResponse InvoiceData { get; init; }

        /// <summary>
        /// Ivoice builder service
        /// </summary>
        public IInvoiceBuilder Builder { get; set; }

        /// <summary>
        /// Call the builder method
        /// </summary>
        /// <returns></returns>
        public abstract string Build();

        public Message(InvoiceResponse invoiceData)
        {
            InvoiceData = invoiceData;
        }
    }
}
