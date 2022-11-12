using Moq;
using MVP.Data.Enums;
using MVP.Services.Exceptions;
using MVP.Data.Models;
using MVP.Services;
using MVP.Services.DataModels;
using MVP.Services.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.Test
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
            _countryRepositoryMock.Setup(x => x.GetByName("Hungary")).Returns(new Country() { Name = "Hungary", Tax = 27 });

            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(x => x.GetByName("Apple")).Returns(new Product() { Name = "Apple", Price = 100 });

            _invoiceProcessorServic = new InvoiceProcessorService(_countryRepositoryMock.Object, _productRepositoryMock.Object);
        }

        [Test]
        public async Task CheckAndParseInvoice_GoodData_OK()
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
        public void CheckAndParseInvoice_UnsupportedCountry_ValidationException()
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

            Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request), $"Error: {request.Country} country does not supported!");
        }

        [Test]
        public void CheckAndParseInvoice_UnsupportedProduct_ValidationException()
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

            Assert.ThrowsAsync<ValidationException>(async () =>  await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request), $"Error: {request.Products[0].Name} product does not supported!");
        }

        [Test]
        public void CheckAndParseInvoice_WithoutProduct_ValidationException()
        {
            var request = new InvoiceRequest()
            {
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };

            Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request), "Error: Please give one or more products!");
        }

        [Test]
        public void CheckAndParseInvoice_WithoutEmail_ValidationException()
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

            Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request), "Email Address is invalid!");
        }

        [Test]
        public void CheckAndParseInvoice_BadInvoiceFormat_ValidationException()
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

            Assert.ThrowsAsync<ValidationException>(async () => await _invoiceProcessorServic.ValidateAndMapInvoiceAsync(request), $"InvoiceFormat is invalid!");
        }
    }
}
