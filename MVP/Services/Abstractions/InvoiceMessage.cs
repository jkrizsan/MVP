using Services.DataModels;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class InvoiceMessage : Message
    {
        public InvoiceMessage(InvoiceResponse InvoiceData):base(InvoiceData)
        {}

        /// <inheritdoc />
        public override async Task<string> BuildAsync()
        {
            return await Builder.BuildAsync(InvoiceData);
        }
    }
}
