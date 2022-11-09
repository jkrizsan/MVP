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
        /// <param name="response"></param>
        /// <returns></returns>
        string CreateInvoice(InvoiceResponse response);

        /// <summary>
        /// Send Invoice Via Email if needed
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="invoiceResponse"></param>
        /// <returns></returns>
        void SendInvoiceViaEmail(string invoice, InvoiceResponse invoiceResponse);
    }
}
