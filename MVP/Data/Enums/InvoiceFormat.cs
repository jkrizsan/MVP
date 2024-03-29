﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Data.Enums
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
