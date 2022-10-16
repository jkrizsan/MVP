using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MVP.Data.Enums
{
    /// <summary>
    /// Invoice Format
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InvoiceFormat
    {
        [JsonProperty("")]
        Unknown = 0,
        JSON,
        HTML
    }
}
