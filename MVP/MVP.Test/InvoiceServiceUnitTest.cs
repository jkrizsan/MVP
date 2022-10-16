using Moq;
using MVP.Data.Enums;
using MVP.Data.Models;
using MVP.Services;
using MVP.Services.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace MVP.Test
{
    class InvoiceServiceUnitTest
    {
        private InvoiceService invoiceService;

        [SetUp]
        public void Setup()
        {
            var countryservice = new Mock<ICountryRepository>();
            countryservice.Setup(x => x.GetByName("Hungary")).Returns(new Country() {Name = "Hungary", Tax = 27 });

            var productService = new Mock<IProductRepository>();
            productService.Setup(x => x.GetByName("Apple")).Returns(new Product() { Name = "Apple", Price = 100 });

            invoiceService = new InvoiceService(countryservice.Object, productService.Object);
        }

        [Test]
        public void CheckAndParseInvoice_GoodData_OK()
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

            var response = invoiceService.CheckAndParseInvoice(request);

            Assert.AreEqual(response.TotalPrices, 254);
            Assert.AreEqual(response.TotalTaxes, 54);
        }

        [Test]
        public void CheckAndParseInvoice_UnsupportedCountry_ErrorMessage()
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

            var response = invoiceService.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains("Error: Poland country does not supported!"));
        }

        [Test]
        public void CheckAndParseInvoice_UnsupportedProduct_ErrorMessage()
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

            var response = invoiceService.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains("Error: Car product does not supported!"));
        }

        [Test]
        public void CheckAndParseInvoice_WithoutProduct_ErrorMessage()
        {
            var request = new InvoiceRequest()
            {
                Country = "Hungary",
                InvoiceFormat = InvoiceFormat.JSON,
                SendEmail = true,
                EmailAddress = "something@something.com"
            };
            var response = invoiceService.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains("Error: Please give one or more products!"));
        }

        [Test]
        public void CheckAndParseInvoice_WithoutEmail_ErrorMessage()
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

            var response = invoiceService.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains("Error: Please give a valid Email Address!"));
        }

        [Test]
        public void CheckAndParseInvoice_BadInvoiceFormat_ErrorMessage()
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

            var response = invoiceService.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains($"Error: '{InvoiceFormat.Unknown}' invoice format does not supported!"));
        }
    }
}
