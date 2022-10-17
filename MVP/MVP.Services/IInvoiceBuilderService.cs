using MVP.Data.Models;

namespace MVP.Services
{
    /// <summary>
    /// Interface of InvoiceBuilder service
    /// </summary>
    public interface IInvoiceBuilderService
    {
        /// <summary>
        /// Build the final invoice format
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        string Build(InvoiceResponse response);
    }
}
