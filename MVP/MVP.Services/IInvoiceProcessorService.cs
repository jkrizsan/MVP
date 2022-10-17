using MVP.Data.Models;

namespace MVP.Services
{
    /// <summary>
    /// Interface of the InvoiceProcessorService
    /// </summary>
    public interface IInvoiceProcessorService
    {
        /// <summary>
        /// Validate and parse invoice request data
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        InvoiceResponse CheckAndParseInvoice(InvoiceRequest requestDto);
    }
}
