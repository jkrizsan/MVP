using MVP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.API
{
    public class InvoiceResponseDto
    {
        public List<Product> Products { get; set; }
        public Country Country { get; set; }
        public InvoiceResponseDto()
        {
            Country = new Country();
            Products = new List<Product>();
        }
    }
}
