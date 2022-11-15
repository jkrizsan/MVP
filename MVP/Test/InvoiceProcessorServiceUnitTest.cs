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

namespace Test
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

            var response = await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request);

            Assert.AreEqual(response.TotalPrices, 254);
            Assert.AreEqual(response.TotalTaxes, 54);
        }

        [Test]
        public async Task ValidateAndMapInvoiceAsync_RequestParamIsNull_Error()
        {
            Exception ex = Assert.ThrowsAsync<NullReferenceException>(async ()
                => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(null));

            Assert.That(ex.Message, Is.EqualTo("The 'request' is null"));
        }

        [Test]
        public void ValidateAndMapInvoiceAsync_UnsupportedCountry_ValidationException()
        {
            var request = new InvoiceRequest()
            {
                Products = new List<InvoiceProduct>()
                {
                    new InvoiceProduct(){ Name = "Apple", Quantity = 2}
                },
                Country = "Poland",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo($"The '{request.Country}' country does not supported!"));
        }

        [Test]
        public void ValidateAndMapInvoiceAsync_UnsupportedProduct_ValidationException()
        {
            var request = new InvoiceRequest()
            {
                Products = new List<InvoiceProduct>()
                {
                    new InvoiceProduct(){ Name = "Car", Quantity = 2}
                },
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () =>  await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo($"The '{request.Products[0].Name}' product does not supported!"));
        }

        [Test]
        public void ValidateAndMapInvoiceAsync_WithoutProduct_ValidationException()
        {
            var request = new InvoiceRequest()
            {
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo("Please give one or more products!"));
        }

        [Test]
        public void ValidateAndMapInvoiceAsync_WithoutEmail_ValidationException()
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

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo("Email Address is invalid!"));
        }

        [Test]
        public void ValidateAndMapInvoiceAsync_WithBadEmail_ValidationException()
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

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo("Email Address is invalid!"));
        }

        [Test]
        public void ValidateAndMapInvoiceAsync_BadInvoiceFormat_ValidationException()
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

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request));

            Assert.That(ex.ErrorMessage, Is.EqualTo("InvoiceFormat is invalid!"));
        }
    }
}
