using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVP.Services;

namespace MVP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> logger;
        private readonly ICountryService countryService;
        private readonly IProductService productService;
        public InvoiceController(ILogger<InvoiceController> logger,
            ICountryService countryService, IProductService productService)
        {
            this.logger = logger;
            this.countryService = countryService;
            this.productService = productService;
        }

        [HttpGet]
        public IEnumerable<InvoiceRequestDto> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new InvoiceRequestDto
            {
                Country = "Finland"
            })
            .ToArray();
        }

        [HttpPost]
        public string Post([FromBody]InvoiceRequestDto invoiceDto)
        {
            if (invoiceDto is null)
            {
                throw new ArgumentNullException($"Method name: {nameof(Post)}");
            }
            InvoiceResponseDto responseDto = new InvoiceResponseDto();
            var ret = "";
            var country = countryService.GetCountryByName(invoiceDto.Country);
            if(country is null)
            {
                return $"Error: {invoiceDto.Country} country does not supported!";
            }
            responseDto.Country = country;
            if (invoiceDto.Products is null || invoiceDto.Products.Count.Equals(0))
            {
                return "Error: Please give one or more products!";
            }
            if (invoiceDto.SendEmail.Equals("True") && string.IsNullOrEmpty(invoiceDto.EmailAddress))
            {
                return "Error: Please give a valid Email Address!";
            }

            foreach (var p in invoiceDto.Products)
            {
                var prod = productService.GetProductByName(p.Name);
                if(prod is null)
                {
                    return $"Error: {p.Name} product does not supported!";
                }
                for (int i = 0; i < p.Quantity; i++)
                {
                    responseDto.Products.Add(prod);
                }
            }

            ret = invoiceDto.ToString();
            return ret; // invoice.Temperature.ToString();
        }
    }
}
