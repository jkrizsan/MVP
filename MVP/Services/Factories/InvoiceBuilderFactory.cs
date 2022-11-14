namespace Services.Factories
{
    /// <summary>
    /// InvoiceBuilderFactory class
    /// </summary>
    public class InvoiceBuilderFactory : IInvoiceBuilderFactory
    {
        /// <inheritdoc />
        public T Create<T>() where T : new()
        {
            return new T();
        }
    }
}
