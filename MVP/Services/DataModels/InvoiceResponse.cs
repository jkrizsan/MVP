using Data.Enums;
using Data.Models;
using System.Collections.Generic;

namespace Services.DataModels
{
    /// <summary>
    /// Dto class for Invoice Response
    /// </summary>
    public class InvoiceResponse
    {
        /// <summary>
        /// List of Product Pricess
        /// </summary>
        public List<ProductPrice> ProductPricess { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Invoice Format
        /// </summary>
        public InvoiceFormat InvoiceFormat { get; set; }
        
        /// <summary>
        /// Send Email
        /// </summary>
        public bool SendEmail { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Sum of the Prices
        /// </summary>
        public double TotalPrices { get; set; }

        /// <summary>
        /// Sum of the Taxes
        /// </summary>
        public double TotalTaxes { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceResponse()
        {
            Country = new Country();
            ProductPricess = new List<ProductPrice>();
        }
    }
}
