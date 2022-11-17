using Services.DataModels;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Interface of the InvoiceManager Service
    /// </summary>
    public interface IInvoiceManagerService
    {
        /// <summary>
        /// Manage Invoice, Create the new invoice, Send it via Email if needed
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        Task<string> ManageInvoiceAsync(InvoiceResponse response);
    }
}
