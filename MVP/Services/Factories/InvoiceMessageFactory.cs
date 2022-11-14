using Services.DataModels;
using Services.Abstractions;

namespace Services.Factories
{
    /// <summary>
    /// InvoiceMessageFactory class
    /// </summary>
    public class InvoiceMessageFactory : IMessageFactory
    {
        /// <inheritdoc />
        public InvoiceMessage Create(InvoiceResponse response)
        {
            return new InvoiceMessage(response);
        }
    }
}
