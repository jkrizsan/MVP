using Data.Enums;
using Services.Exceptions;
using Services.DataModels;
using Services.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace Services
{
    /// <summary>
    /// InvoiceProcessor Service
    /// </summary>
    public class InvoiceProcessorService : IInvoiceProcessorService
    {
        private readonly ICountryRepository _countryRepository;

        private readonly IProductRepository _productRepository;

        public InvoiceProcessorService(ICountryRepository countryRepository,
            IProductRepository productRepository)
        {
            _countryRepository = countryRepository;
            _productRepository = productRepository;
        }

        /// <inheritdoc />
        public async Task<InvoiceResponse> ValidateAndMapInvoiceAsync(InvoiceRequest request)
        {
            if (request is null)
            {
                throw new NullReferenceException(Constants.GetString(Constants.NullreferenceException, nameof(request)));
            }

            var response = new InvoiceResponse();

            await MapSendEmailAsync(request, response);
            await MapEmailAddressAsync(request, response);
            await MapInvoiceFormatAsync(request, response);
            await MapCountryAsync(request, response);
            await MapProductAsync(request, response);
            await SetPricesAsync(request, response);
            await SetTaxesAsync(request, response);

            return response;
        }

        private async Task MapSendEmailAsync(InvoiceRequest request, InvoiceResponse response)
        {
            response.SendEmail = request?.SendEmail ?? false;
        }

        private async Task MapEmailAddressAsync(InvoiceRequest request, InvoiceResponse response)
        {
            if (response.SendEmail && string.IsNullOrEmpty(request.EmailAddress)
                || request.EmailAddress?.Contains(Constants.At) == false)
            {
                throw new ValidationException(Constants.EmailAddressError);
            }

            response.EmailAddress = request.EmailAddress;
        }

        private async Task MapInvoiceFormatAsync(InvoiceRequest request, InvoiceResponse response)
        {
            if (request.InvoiceFormat == InvoiceFormat.Unknown)
            {
                throw new ValidationException(Constants.InvalidInvoiceFormat);
            }

            response.InvoiceFormat = request.InvoiceFormat;
        }

        private async Task MapProductAsync(InvoiceRequest request, InvoiceResponse response)
        {
            if (request.Products is null || request.Products.Count.Equals(0))
            {
                throw new ValidationException(Constants.MissingProduct);
            }

            foreach (var prod in request.Products)
            {
                var prodFromDb = await _productRepository.GetByNameAsync(prod.Name);
                if (prodFromDb is null)
                {
                    throw new ValidationException(Constants.GetString(Constants.UnsupportedProduct, prod.Name));
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

        private async Task MapCountryAsync(InvoiceRequest request, InvoiceResponse response)
        {
            var country = await _countryRepository.GetByNameAsync(request.Country);

            if (country is null)
            {
                throw new ValidationException(Constants.GetString(Constants.UnsupportedCountry, request.Country));
            }

            response.Country = country;
        }

        private async Task SetPricesAsync(InvoiceRequest request, InvoiceResponse response)
        {
            response.TotalPrices = Math.Round(response.ProductPricess.Select(x => x.Price).ToList().Sum(), 2);
        }

        private async Task SetTaxesAsync(InvoiceRequest request, InvoiceResponse response)
        {
            response.TotalTaxes = Math.Round(response.ProductPricess.Select(x => x.Tax).ToList().Sum(), 2);
        }
    }
}
