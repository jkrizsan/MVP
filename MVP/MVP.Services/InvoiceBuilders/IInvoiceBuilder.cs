using MVP.Services.DataModels;
using System.Threading.Tasks;

namespace Services.InvoiceBuilders
{
    /// <summary>
    /// Interface of InvoiceBuilder
    /// </summary>
    public interface IInvoiceBuilder
    {
        /// <summary>
        /// Build the final invoice format
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        Task<string> BuildAsync(InvoiceResponse response);
    }
}
