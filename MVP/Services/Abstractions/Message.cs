using Services.DataModels;
using Services.InvoiceBuilders;
using System.Threading.Tasks;

namespace Services.Abstractions
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
        public abstract Task<string> BuildAsync();

        public Message(InvoiceResponse invoiceData)
        {
            InvoiceData = invoiceData;
        }
    }
}
