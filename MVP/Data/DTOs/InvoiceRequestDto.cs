using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVP.Data.DTOs
{
    public class InvoiceRequestDto
    {
        public List<ProductDto> Products { get; set; }
        public string Country { get; set; }
        public string InvoiceFormat { get; set; }
        public string SendEmail { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
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
