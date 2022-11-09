
namespace MVP.Services.Factories
{
    /// <summary>
    /// Interface of InvoiceBuilderFactory
    /// </summary>
    public interface IInvoiceBuilderFactory
    {
        /// <summary>
        /// Create an InvoiceBuilder instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Create<T>() where T : new();
    }
}
