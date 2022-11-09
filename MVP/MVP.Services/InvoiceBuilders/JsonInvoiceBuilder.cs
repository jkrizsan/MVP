using MVP.Services.DataModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Services.InvoiceBuilders
{
    /// <summary>
    /// JSON Invoice Builder
    /// </summary>
    public class JsonInvoiceBuilder : IInvoiceBuilder
    {
        /// <inheritdoc />
        public string Build(InvoiceResponse response)
        {
            string result = string.Empty;

            try
            {
                result = JsonConvert.SerializeObject(response);
            }
            catch
            {
                throw new ValidationException($"JSON Serialize error happened!");
            }

            return result;
        }
    }
}
