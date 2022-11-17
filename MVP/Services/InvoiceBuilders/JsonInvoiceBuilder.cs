using Services.DataModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Data;

namespace Services.InvoiceBuilders
{
    /// <summary>
    /// JSON Invoice Builder
    /// </summary>
    public class JsonInvoiceBuilder : IInvoiceBuilder
    {
        /// <inheritdoc />
        public async Task<string> BuildAsync(InvoiceResponse response)
        {
            string result = string.Empty;

            try
            {
                result = JsonConvert.SerializeObject(response);
            }
            catch
            {
                throw new ValidationException(Constants.JsonSerializeError);
            }

            return result;
        }
    }
}
