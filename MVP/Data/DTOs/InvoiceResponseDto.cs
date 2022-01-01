using MVP.Data.Enums;
using MVP.Data.Models;
using System.Collections.Generic;

namespace MVP.Data.DTOs
{
    /// <summary>
    /// Dto class for Invoice Response
    /// </summary>
    public class InvoiceResponseDto
    {
        /// <summary>
        /// List of Product Pricess
        /// </summary>
        public List<ProductPriceDto> ProductPricess { get; set; }

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
        /// Error Message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceResponseDto()
        {
            Country = new Country();
            ProductPricess = new List<ProductPriceDto>();
        }
    }
}
