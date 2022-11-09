using MVP.Services.DataModels;

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
    }
}
