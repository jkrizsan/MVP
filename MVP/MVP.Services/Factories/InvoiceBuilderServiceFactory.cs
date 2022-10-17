namespace MVP.Services.Factories
{
    /// <summary>
    /// InvoiceBuilderServiceFactory class
    /// </summary>
    public class InvoiceBuilderServiceFactory : IInvoiceBuilderServiceFactory
    {
        /// <inheritdoc />
        public T Create<T>() where T : new()
        {
            return new T();
        }
    }
}
