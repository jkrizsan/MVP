using MVP.Data.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVP.Data.Models
{
    /// <summary>
    /// Dto class for Invoice Request
    /// </summary>
    public class InvoiceRequest
    {
        /// <summary>
        /// List of Products
        /// </summary>
        public List<InvoiceProduct> Products { get; set; }

        /// <summary>
        /// Name of the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Invoice Format
        /// </summary>
        public InvoiceFormat InvoiceFormat { get; set; }

        /// <summary>
        /// Send Email or Not after the invoice is created
        /// </summary>
        public bool SendEmail { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceRequest()
        {
            Products = new List<InvoiceProduct>();
        }
    }
}
