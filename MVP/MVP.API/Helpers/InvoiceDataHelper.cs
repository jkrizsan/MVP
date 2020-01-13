using MVP.API.DTOs;
using MVP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.API.Helpers
{
    public class InvoiceDataHelper : IInvoiceDataHelper
    {
        private readonly ICountryService countryService;
        private readonly IProductService productService;
        public InvoiceDataHelper(ICountryService countryService, IProductService productService)
        {
            this.countryService = countryService;
            this.productService = productService;
        }

        #region Check And Parse Invoice Datas

        private void ParseSendEmailAndEmailAddress(InvoiceRequestDto requestDto, InvoiceResponseDto responseDto)
        {
            responseDto.SendEmail = requestDto.SendEmail.ToLowerInvariant()
                .Equals("true") ? true : false;

            if (responseDto.SendEmail && string.IsNullOrEmpty(requestDto.EmailAddress))
            {
                responseDto.ErrorMessage = "Error: Please give a valid Email Address!";
                return;
            }
            responseDto.EmailAddress = requestDto.EmailAddress;
        }

        private void ParseInvoiceFormat(InvoiceRequestDto requestDto, InvoiceResponseDto responseDto)
        {
            switch (requestDto.InvoiceFormat)
            {
                case "JSON":
                    responseDto.InvoiceFormat = InvoiceFormat.JSON;
                    break;
                case "HTML":
                    responseDto.InvoiceFormat = InvoiceFormat.HTML;
                    break;
                default:
                    responseDto.ErrorMessage = $"Error: {requestDto.InvoiceFormat} invoice format does not supported!";
                    break;
            }
        }

        private void ParseProduct(InvoiceRequestDto requestDto, InvoiceResponseDto responseDto)
        {
            if (requestDto.Products is null || requestDto.Products.Count.Equals(0))
            {
                responseDto.ErrorMessage = "Error: Please give one or more products!";
                return;
            }
            foreach (var p in requestDto.Products)
            {
                var prod = productService.GetProductByName(p.Name);
                if (prod is null)
                {
                    responseDto.ErrorMessage = $"Error: {p.Name} product does not supported!";
                    return;
                }
                for (int i = 0; i < p.Quantity; i++)
                {
                    var pp = new ProductPriceDto();
                    pp.Name = prod.Name;
                    pp.Tax = (prod.Price * responseDto.Country.Tax) / 100.0;
                    pp.Price = prod.Price + pp.Tax;
                    responseDto.ProductPricess.Add(pp);
                }
            }

        }

        private void ParseCountry(InvoiceRequestDto requestDto, InvoiceResponseDto responseDto)
        {
            var country = countryService.GetCountryByName(requestDto.Country);
            if (country is null)
            {
                responseDto.ErrorMessage = $"Error: {requestDto.Country} country does not supported!";
                return;
            }
            responseDto.Country = country;
        }

        private void SetPricesAndTaxes(InvoiceRequestDto requestDto, InvoiceResponseDto responseDto)
        {
            responseDto.TotalTaxes = Math.Round(responseDto.ProductPricess.Select(x => x.Tax).ToList().Sum(), 2);
            responseDto.TotalPrices = Math.Round(responseDto.ProductPricess.Select(x => x.Price).ToList().Sum(), 2);
        }

        #endregion Check And Parse Invoice Datas

        public InvoiceResponseDto CheckAndParseInvoice(InvoiceRequestDto requestDto)
        {
            var responseDto = new InvoiceResponseDto();

            ParseSendEmailAndEmailAddress(requestDto, responseDto);
            ParseInvoiceFormat(requestDto, responseDto);
            ParseCountry(requestDto, responseDto);
            ParseProduct(requestDto, responseDto);
            SetPricesAndTaxes(requestDto, responseDto);

            return responseDto;
        }
    }
}
