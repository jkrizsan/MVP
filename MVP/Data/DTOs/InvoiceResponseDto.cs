using MVP.Data.Enums;
using MVP.Data.Models;
using System.Collections.Generic;

namespace MVP.Data.DTOs
{
    public class InvoiceResponseDto
    {
        public List<ProductPriceDto> ProductPricess { get; set; }
        public Country Country { get; set; }
        public InvoiceFormat InvoiceFormat { get; set; }
        public bool SendEmail { get; set; }
        public string EmailAddress { get; set; }
        public double TotalPrices { get; set; }
        public double TotalTaxes { get; set; }
        public string ErrorMessage { get; set; }
        public InvoiceResponseDto()
        {
            Country = new Country();
            ProductPricess = new List<ProductPriceDto>();
        }
    }
}
