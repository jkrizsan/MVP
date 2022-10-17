using MVP.Data.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVP.Services
{
    /// <summary>
    /// JSON Invoice Builder Service class
    /// </summary>
    public class JsonInvoiceBuilderService : IInvoiceBuilderService
    {
        /// <inheritdoc />
        public string Build(InvoiceResponse response)
        {
            string result = string.Empty;

            try
            {
                result = JsonConvert.SerializeObject(response);
            }
            catch (Exception e)
            {
                throw new ValidationException($"JSON format exception: {e.Message}");
            }

            return result;
        }
    }
}
