using MVP.API.DTOs;
using MVP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.API
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
