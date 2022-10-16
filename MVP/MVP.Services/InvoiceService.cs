using MVP.Data.Enums;
using MVP.Data.Models;
using MVP.Services.Repositories;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;

namespace MVP.Services
{
    /// <summary>
    /// Invoice Service
    /// </summary>
    public class InvoiceService : IInvoiceService
    {
        private readonly ICountryRepository _countryRepository;

        private readonly IProductRepository _productRepository;

        public InvoiceService(ICountryRepository countryRepository, IProductRepository productRepository)
        {
            _countryRepository = countryRepository;
            _productRepository = productRepository;
        }

        public string CreateInvoice(InvoiceResponse response) =>
            response.InvoiceFormat switch
            {
                InvoiceFormat.JSON => BuildJSONInvoice(response),
                InvoiceFormat.HTML => BuildHTMLInvoice(response),
                _ => "Error: Unexpected invoice format!",
            };

        /// <summary>
        /// Convert request data to response data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public InvoiceResponse CheckAndParseInvoice(InvoiceRequest request)
        {
            var response = new InvoiceResponse();

            ParseSendEmailAndEmailAddress(request, response);
            ParseInvoiceFormat(request, response);
            ParseCountry(request, response);
            ParseProduct(request, response);
            SetPricesAndTaxes(request, response);

            return response;
        }

        private void ParseSendEmailAndEmailAddress(InvoiceRequest request, InvoiceResponse response)
        {
            response.SendEmail = request.SendEmail;

            if (response.SendEmail && string.IsNullOrEmpty(request.EmailAddress))
            {
                response.ErrorMessage = "Error: Please give a valid Email Address!";
                return;
            }

            response.EmailAddress = request.EmailAddress;
        }

        private InvoiceResponse ParseInvoiceFormat(InvoiceRequest request, InvoiceResponse response)
        {
            if(request.InvoiceFormat == InvoiceFormat.Unknown)
            {
                response.ErrorMessage = $"Error: '{request.InvoiceFormat}' invoice format does not supported!";
            }
            response.InvoiceFormat = request.InvoiceFormat;

            return response;
        }
            //request.InvoiceFormat switch
            //{
            //    "JSON" => response.InvoiceFormat = InvoiceFormat.JSON,
            //    "HTML" => response.InvoiceFormat = InvoiceFormat.HTML,
            //    _ => response.ErrorMessage = $"Error: '{request.InvoiceFormat}' invoice format does not supported!",
            //};

        private void ParseProduct(InvoiceRequest request, InvoiceResponse response)
        {
            if (request.Products is null || request.Products.Count.Equals(0))
            {
                response.ErrorMessage = "Error: Please give one or more products!";
                return;
            }

            foreach (var prod in request.Products)
            {
                var prodFromDb = _productRepository.GetByName(prod.Name);
                if (prodFromDb is null)
                {
                    response.ErrorMessage = $"Error: {prod.Name} product does not supported!";
                    return;
                }
                for (int i = 0; i < prod.Quantity; i++)
                {
                    var pp = new ProductPrice();
                    pp.Name = prodFromDb.Name;
                    pp.Tax = (prodFromDb.Price * response.Country.Tax) / 100.0;
                    pp.Price = prodFromDb.Price + pp.Tax;
                    response.ProductPricess.Add(pp);
                }
            }
        }

        private void ParseCountry(InvoiceRequest request, InvoiceResponse response)
        {
            var country = _countryRepository.GetByName(request.Country);
            if (country is null)
            {
                response.ErrorMessage = $"Error: {request.Country} country does not supported!";
                return;
            }

            response.Country = country;
        }

        private void SetPricesAndTaxes(InvoiceRequest request, InvoiceResponse response)
        {
            response.TotalTaxes = Math.Round(response.ProductPricess.Select(x => x.Tax).ToList().Sum(), 2);

            response.TotalPrices = Math.Round(response.ProductPricess.Select(x => x.Price).ToList().Sum(), 2);
        }

        private string BuildHTMLInvoice(InvoiceResponse responseDto)
        {
            StringBuilder invoice = new StringBuilder(100);

            invoice.Append($@"<!DOCTYPE html>{Environment.NewLine}");
            invoice.Append($@"<html>{Environment.NewLine}");
            invoice.Append($@"<body>{Environment.NewLine}");

            invoice.Append($@"<table border=1>{Environment.NewLine}");
            invoice.Append($@"<thead>{Environment.NewLine}");
            invoice.Append($@"<tr>{Environment.NewLine}");
            invoice.Append($@"<th>Product Name</th>{Environment.NewLine}");
            invoice.Append($@"<th>Product Price</th>{Environment.NewLine}");
            invoice.Append($@"<th>Product Tax</th>{Environment.NewLine}");
            invoice.Append($@"</tr>{Environment.NewLine}");
            invoice.Append($@"</thead>{Environment.NewLine}");
            invoice.Append($@"<tbody>{Environment.NewLine}");

            foreach (var item in responseDto.ProductPricess)
            {
                invoice.Append($@"<tr>{Environment.NewLine}");
                invoice.Append($@"<td>{item.Name}</td>{Environment.NewLine}");
                invoice.Append($@"<td>{item.Price}</td>{Environment.NewLine}");
                invoice.Append($@"<td>{item.Tax}</td>{Environment.NewLine}");
                invoice.Append($@"</tr>{Environment.NewLine}");
            }

            invoice.Append($@"</tbody>{Environment.NewLine}");
            invoice.Append($@"</table>{Environment.NewLine}");

            invoice.Append($@"<table border=1>{Environment.NewLine}");
            invoice.Append($@"<thead>{Environment.NewLine}");
            invoice.Append($@"<tr>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(responseDto.Country)}</th>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(responseDto.Country.Tax)}</th>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(responseDto.EmailAddress)}</th>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(responseDto.TotalPrices)}</th>{Environment.NewLine}");
            invoice.Append($@"<th>{nameof(responseDto.TotalTaxes)}</th>{Environment.NewLine}");
            invoice.Append($@"</tr>{Environment.NewLine}");
            invoice.Append($@"</thead>{Environment.NewLine}");
            invoice.Append($@"</tbody>{Environment.NewLine}");
            invoice.Append($@"<tr>{Environment.NewLine}");
            invoice.Append($@"<td>{responseDto.Country.Name}</td>{Environment.NewLine}");
            invoice.Append($@"<td>{responseDto.Country.Tax}</td>{Environment.NewLine}");
            invoice.Append($@"<td>{responseDto.EmailAddress}</td>{Environment.NewLine}");
            invoice.Append($@"<td>{responseDto.TotalPrices}</td>{Environment.NewLine}");
            invoice.Append($@"<td>{responseDto.TotalTaxes}</td>{Environment.NewLine}");
            invoice.Append($@"</tr>{Environment.NewLine}");
            invoice.Append($@"</tbody>{Environment.NewLine}");
            invoice.Append($@"</table>{Environment.NewLine}");

            invoice.Append($@"</tbody>{Environment.NewLine}");
            invoice.Append($@"</body>{Environment.NewLine}");
            invoice.Append($@"</html>{Environment.NewLine}");
            
            return invoice.ToString();
        }

        private string BuildJSONInvoice(InvoiceResponse responseDto)
        {
            string result = string.Empty;

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
