using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVP.Data.DTOs
{
    /// <summary>
    /// Dto class for Invoice Request
    /// </summary>
    public class InvoiceRequestDto
    {
        /// <summary>
        /// List of Products
        /// </summary>
        public List<ProductDto> Products { get; set; }

        /// <summary>
        /// Name of the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Invoice Format
        /// </summary>
        public string InvoiceFormat { get; set; }

        /// <summary>
        /// Send Email or Not after the invoice is created
        /// </summary>
        public string SendEmail { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceRequestDto()
        {
            Products = new List<ProductDto>();
        }

        public override string ToString()
        {
            var ret = string.Empty;
            if (Products != null)
            {
                foreach (var item in Products)
                {
                    ret = $"{ret}{nameof(item.Name)}:{item.Name} {nameof(item.Quantity)}:{item.Quantity}{Environment.NewLine}";
                }
            }

            ret = $"{ret}{nameof(Country)}:{Country}{Environment.NewLine}";
            ret = $"{ret}{nameof(InvoiceFormat)}:{InvoiceFormat}{Environment.NewLine}";
            ret = $"{ret}{nameof(SendEmail)}:{SendEmail}{Environment.NewLine}";
            ret = $"{ret}{nameof(EmailAddress)}:{EmailAddress}{Environment.NewLine}";

            return ret;
        }
    }
}
