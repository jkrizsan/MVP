using Moq;
using MVP.API;
using MVP.API.Helpers;
using MVP.Data.Models;
using MVP.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace MVP.Test
{
    class InvoiceDataHelperUnitTest
    {
        private InvoiceDataHelper invoiceDataHelper;

        [SetUp]
        public void Setup()
        {
            var countryservice = new Mock<ICountryService>();
            countryservice.Setup(x => x.GetCountryByName("Hungary")).Returns(new Country() {Name = "Hungary", Tax = 27 });

            var productService = new Mock<IProductService>();
            productService.Setup(x => x.GetProductByName("Apple")).Returns(new Product() { Name = "Apple", Price = 100 });

            invoiceDataHelper = new InvoiceDataHelper(countryservice.Object, productService.Object);
        }

        [Test]
        public void InvoiceDataHelper_ok()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Apple", Quantity = 2}
                },
                Country = "Hungary",
                InvoiceFormat = "JSON",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceDataHelper.CheckAndParseInvoice(request);

            Assert.AreEqual(response.TotalPrices, 254);
            Assert.AreEqual(response.TotalTaxes, 54);
        }

        [Test]
        public void InvoiceDataHelper_UnsupportedCountry()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Apple", Quantity = 2}
                },
                Country = "Poland",
                InvoiceFormat = "JSON",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceDataHelper.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains("Error: Poland country does not supported!"));
        }

        [Test]
        public void InvoiceDataHelper_UnsupportedProduct()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Car", Quantity = 2}
                },
                Country = "Hungary",
                InvoiceFormat = "JSON",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceDataHelper.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains("Error: Car product does not supported!"));
        }

        [Test]
        public void InvoiceDataHelper_WithoutProduct()
        {
            var request = new InvoiceRequestDto()
            {
                Country = "Hungary",
                InvoiceFormat = "JSON",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceDataHelper.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains("Error: Please give one or more products!"));
        }

        [Test]
        public void InvoiceDataHelper_WithoutEmail()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Apple", Quantity = 2}
                },
                Country = "Hungary",
                InvoiceFormat = "JSON",
                SendEmail = "true"
            };
            var response = invoiceDataHelper.CheckAndParseInvoice(request);
            Assert.IsTrue(response.ErrorMessage.Contains("Error: Please give a valid Email Address!"));
        }

        [Test]
        public void InvoiceDataHelper_BadInvoiceFormat()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Apple", Quantity = 2},
                },
                Country = "Hungary",
                InvoiceFormat = "TEST",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceDataHelper.CheckAndParseInvoice(request);

            Assert.IsTrue(response.ErrorMessage.Contains("Error: TEST invoice format does not supported!"));
        }
    }
}
