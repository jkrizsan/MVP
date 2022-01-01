using MVP.Data.DTOs;
using MVP.Data.Enums;
using MVP.Services;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MVP.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ICountryService countryService;
        private readonly IProductService productService;
        public InvoiceService(ICountryService countryService, IProductService productService)
        {
            this.countryService = countryService;
            this.productService = productService;
        }

        public string CreateInvoice(InvoiceResponseDto responseDto)
        {
            switch(responseDto.InvoiceFormat)
            {
                case InvoiceFormat.JSON:
                    return BuildJSONInvoice(responseDto);
                case InvoiceFormat.HTML:
                    return BuildHTMLInvoice(responseDto);
                default:
                    return "Error: Unexpected invoice format!";
            }
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

        /// <summary>
        /// Convert request data to response data
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
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

        private string BuildHTMLInvoice(InvoiceResponseDto responseDto)
        {
            string result = $@"<!DOCTYPE html>{Environment.NewLine}";
            result += $@"<html>{Environment.NewLine}";
            result += $@"<body>{Environment.NewLine}";

            result += $@"<table border=1>{Environment.NewLine}";
            result += $@"<thead>{Environment.NewLine}";
            result += $@"<tr>{Environment.NewLine}";
            result += $@"<th>Product Name</th>{Environment.NewLine}";
            result += $@"<th>Product Price</th>{Environment.NewLine}";
            result += $@"<th>Product Tax</th>{Environment.NewLine}";
            result += $@"</tr>{Environment.NewLine}";
            result += $@"</thead>{Environment.NewLine}";
            result += $@"<tbody>{Environment.NewLine}";
            foreach (var item in responseDto.ProductPricess)
            {
                result += $@"<tr>{Environment.NewLine}";
                result += $@"<td>{item.Name}</td>{Environment.NewLine}";
                result += $@"<td>{item.Price}</td>{Environment.NewLine}";
                result += $@"<td>{item.Tax}</td>{Environment.NewLine}";
                result += $@"</tr>{Environment.NewLine}";
            }
            result += $@"</tbody>{Environment.NewLine}";
            result += $@"</table>{Environment.NewLine}";

            result += $@"<table border=1>{Environment.NewLine}";
            result += $@"<thead>{Environment.NewLine}";
            result += $@"<tr>{Environment.NewLine}";       
            result += $@"<th>{nameof(responseDto.Country)}</th>{Environment.NewLine}";
            result += $@"<th>{nameof(responseDto.Country.Tax)}</th>{Environment.NewLine}";
            result += $@"<th>{nameof(responseDto.EmailAddress)}</th>{Environment.NewLine}";
            result += $@"<th>{nameof(responseDto.TotalPrices)}</th>{Environment.NewLine}";
            result += $@"<th>{nameof(responseDto.TotalTaxes)}</th>{Environment.NewLine}";
            result += $@"</tr>{Environment.NewLine}";
            result += $@"</thead>{Environment.NewLine}";
            result += $@"</tbody>{Environment.NewLine}";
            result += $@"<tr>{Environment.NewLine}";
            result += $@"<td>{responseDto.Country.Name}</td>{Environment.NewLine}";
            result += $@"<td>{responseDto.Country.Tax}</td>{Environment.NewLine}";
            result += $@"<td>{responseDto.EmailAddress}</td>{Environment.NewLine}";
            result += $@"<td>{responseDto.TotalPrices}</td>{Environment.NewLine}";
            result += $@"<td>{responseDto.TotalTaxes}</td>{Environment.NewLine}";
            result += $@"</tr>{Environment.NewLine}";
            result += $@"</tbody>{Environment.NewLine}";
            result += $@"</table>{Environment.NewLine}";

            result += $@"</tbody>{Environment.NewLine}";
            result += $@"</body>{Environment.NewLine}";
            result += $@"</html>{Environment.NewLine}";
            
            return result;
        }

        private string BuildJSONInvoice(InvoiceResponseDto responseDto)
        {
            string result = "";

            try
            {
                result = JsonConvert.SerializeObject(responseDto);
            }
            catch (Exception e)
            {
                result = $"JSON format exception: {e.Message}";
            }

            return result;
        }
    }
}
