using Services.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
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

        /// <summary>
        /// Receive a list of previously created invoices
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<HistoryResponse>> GetInvoicesAsync(HistoryRequest request);
    }
}
