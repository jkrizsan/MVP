using Moq;
using Data.Enums;
using Services.Exceptions;
using Data.Models;
using Services;
using Services.DataModels;
using Services.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Data;

namespace Tests
{
    public class InvoiceProcessorServiceUnitTest
    {
        private IInvoiceProcessorService _invoiceProcessorServic;

        private Mock<ICountryRepository> _countryRepositoryMock;

        private Mock<IProductRepository> _productRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _countryRepositoryMock = new Mock<ICountryRepository>();
            _countryRepositoryMock.Setup(x => x.GetByNameAsync("Hungary")).ReturnsAsync(new Country() { Name = "Hungary", Tax = 27 });

            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(x => x.GetByNameAsync("Apple")).ReturnsAsync(new Product() { Name = "Apple", Price = 100 });

            _invoiceProcessorServic = new InvoiceProcessorService(_countryRepositoryMock.Object, _productRepositoryMock.Object);
        }

        [Test]
        public async Task ValidateAndMapInvoiceAsync_GoodData_OK()
        {
            var request = new InvoiceRequest()
            {
                Products = new List<InvoiceProduct>()
                {
                    new InvoiceProduct(){ Name = "Apple", Quantity = 2}
                },
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            var response = await _invoiceProcessorServic.MapInvoiceAsync(request);

            Assert.AreEqual(response.TotalPrices, 254);
            Assert.AreEqual(response.TotalTaxes, 54);
        }

        [Test]
        public async Task ValidateAndMapInvoiceAsync_RequestParamIsNull_Error()
        {
            Exception ex = Assert.ThrowsAsync<NullReferenceException>(async ()
                => await _invoiceProcessorServic.MapInvoiceAsync(null));

            Assert.That(ex.Message, Is.EqualTo(Constants.GetString(Constants.NullreferenceException, "request")));
        }

        [Test]
        public void ValidateAndMapInvoiceAsync_UnsupportedCountry_ValidationException()
        {
            const string countryName = "Poland";

            var request = new InvoiceRequest()
            {
                Products = new List<InvoiceProduct>()
                {
                    new InvoiceProduct(){ Name = "Apple", Quantity = 2}
                },
                Country = countryName,
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => 
                await _invoiceProcessorServic.MapInvoiceAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo(Constants.GetString(Constants.UnsupportedCountry, countryName)));
        }

        [Test]
        public void ValidateAndMapInvoiceAsync_UnsupportedProduct_ValidationException()
        {
            const string productName = "Car";

            var request = new InvoiceRequest()
            {
                Products = new List<InvoiceProduct>()
                {
                    new InvoiceProduct(){ Name = productName, Quantity = 2}
                },
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => 
                await _invoiceProcessorServic.MapInvoiceAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo(Constants.GetString(Constants.UnsupportedProduct, productName)));
        }

        [Test]
        public void ValidateInvoiceRequestAsync_WithoutProduct_ValidationException()
        {
            var request = new InvoiceRequest()
            {
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => 
                await _invoiceProcessorServic.ValidateInvoiceRequestAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo(Constants.MissingProduct));
        }

        [Test]
        public void ValidateInvoiceRequestAsync_WithoutEmail_ValidationException()
        {
            var request = new InvoiceRequest()
            {
                Products = new List<InvoiceProduct>()
                {
                    new InvoiceProduct(){ Name = "Apple", Quantity = 2}
                },
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => 
                await _invoiceProcessorServic.ValidateInvoiceRequestAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo(Constants.EmailAddressError));
        }

        [Test]
        public void ValidateInvoiceRequestAsync_WithWrongEmailAddress_ValidationException()
        {
            var request = new InvoiceRequest()
            {
                Products = new List<InvoiceProduct>()
                {
                    new InvoiceProduct() { Name = "Apple", Quantity = 2 }
                },
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "test"
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => 
                await _invoiceProcessorServic.ValidateInvoiceRequestAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo(Constants.EmailAddressError));
        }

        [Test]
        public void ValidateInvoiceRequestAsync_BadInvoiceFormat_ValidationException()
        {
            var request = new InvoiceRequest()
            {
                Products = new List<InvoiceProduct>()
                {
                    new InvoiceProduct(){ Name = "Apple", Quantity = 2},
                },
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.Unknown,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => 
                await _invoiceProcessorServic.ValidateInvoiceRequestAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo(Constants.InvalidInvoiceFormat));
        }
    }
}
