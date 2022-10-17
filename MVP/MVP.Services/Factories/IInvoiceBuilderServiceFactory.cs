namespace MVP.Services.Factories
{
    /// <summary>
    /// Interface of InvoiceBuilderServiceFactory
    /// </summary>
    public interface IInvoiceBuilderServiceFactory
    {
        /// <summary>
        /// Create an InvoiceBuilderService instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Create<T>() where T : new();
    }
}
