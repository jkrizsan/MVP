using MVP.Data.Models;

namespace MVP.Services
{
    /// <summary>
    /// Interface for Invoice Service
    /// </summary>
    public interface IInvoiceService
    {
        /// <summary>
        /// Create Invoice
        /// </summary>
        /// <param name="responseDto"></param>
        /// <returns></returns>
        string CreateInvoice(InvoiceResponse responseDto);

        /// <summary>
        /// Validate and parse invoice request data
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        InvoiceResponse CheckAndParseInvoice(InvoiceRequest requestDto);
    }
}
