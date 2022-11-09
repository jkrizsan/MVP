using MVP.Services.DataModels;

namespace MVP.Services.Abstractions
{
    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class InvoiceMessage : Message
    {
        public InvoiceMessage(InvoiceResponse InvoiceData):base(InvoiceData)
        {}

        /// <inheritdoc />
        public override string Build()
        {
            return Builder.Build(InvoiceData);
        }
    }
}
