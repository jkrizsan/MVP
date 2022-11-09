﻿using MVP.Data.Enums;
using MVP.Services.Exceptions;
using MVP.Services.DataModels;
using MVP.Services.Repositories;
using System;
using System.Linq;

namespace MVP.Services
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
        public InvoiceResponse CheckAndParseInvoice(InvoiceRequest request)
        {
            var response = new InvoiceResponse();

            MapSendEmail(request, response);
            MapEmailAddress(request, response);
            MapInvoiceFormat(request, response);
            MapCountry(request, response);
            MapProduct(request, response);
            SetPrices(request, response);
            SetTaxes(request, response);

            return response;
        }

        private void MapSendEmail(InvoiceRequest request, InvoiceResponse response)
        {
            response.SendEmail = request.SendEmail;
        }

        private void MapEmailAddress(InvoiceRequest request, InvoiceResponse response)
        {
            if (response.SendEmail && string.IsNullOrEmpty(request.EmailAddress))
            {
                throw new ValidationException("Email Address is invalid!");
            }

            response.EmailAddress = request.EmailAddress;
        }

        private InvoiceResponse MapInvoiceFormat(InvoiceRequest request, InvoiceResponse response)
        {
            if (request.InvoiceFormat == InvoiceFormat.Unknown)
            {
                throw new ValidationException("InvoiceFormat is invalid!");
            }

            response.InvoiceFormat = request.InvoiceFormat;

            return response;
        }

        private void MapProduct(InvoiceRequest request, InvoiceResponse response)
        {
            if (request.Products is null || request.Products.Count.Equals(0))
            {
                throw new ValidationException("Please give one or more products!");
            }

            foreach (var prod in request.Products)
            {
                var prodFromDb = _productRepository.GetByName(prod.Name);
                if (prodFromDb is null)
                {
                    throw new ValidationException($"The '{prod.Name}' product does not supported!");
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

        private void MapCountry(InvoiceRequest request, InvoiceResponse response)
        {
            var country = _countryRepository.GetByName(request.Country);

            if (country is null)
            {
                throw new ValidationException($"The '{request.Country}' country does not supported!");
            }

            response.Country = country;
        }

        private void SetPrices(InvoiceRequest request, InvoiceResponse response)
        {
            response.TotalPrices = Math.Round(response.ProductPricess.Select(x => x.Price).ToList().Sum(), 2);
        }

        private void SetTaxes(InvoiceRequest request, InvoiceResponse response)
        {
            response.TotalTaxes = Math.Round(response.ProductPricess.Select(x => x.Tax).ToList().Sum(), 2);
        }
    }
}