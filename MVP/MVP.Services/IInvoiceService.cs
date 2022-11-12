using MVP.Services.DataModels;
using System.Threading.Tasks;

namespace MVP.Services
{
    /// <summary>
    /// Interface for Invoice Service
    /// </summary>
    public interface IInvoiceService
    {
        /// <summary>
        /// Manage Invoice
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        Task<string> ManageInvoiceAsync(InvoiceResponse response);
    }
}
