using Services.DataModels;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Interface of the InvoiceProcessorService
    /// </summary>
    public interface IInvoiceProcessorService
    {
        /// <summary>
        /// Validate the Invoice request data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task ValidateInvoiceRequestAsync(InvoiceRequest request);

        /// <summary>
        /// Map invoice request data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<InvoiceResponse> MapInvoiceAsync(InvoiceRequest request);
    }
}
