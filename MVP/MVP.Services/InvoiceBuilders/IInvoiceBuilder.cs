using MVP.Services.DataModels;

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
        string Build(InvoiceResponse response);
    }
}
