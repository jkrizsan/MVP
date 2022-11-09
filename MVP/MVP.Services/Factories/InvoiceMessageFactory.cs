using MVP.Services.DataModels;
using MVP.Services.Abstractions;

namespace MVP.Services.Factories
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
