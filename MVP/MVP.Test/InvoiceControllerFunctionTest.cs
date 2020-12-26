using Microsoft.EntityFrameworkCore;
using MVP.API;
using MVP.API.Controllers;
using MVP.API.Helpers;
using MVP.Data;
using MVP.Data.Models;
using MVP.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MVP.Test
{
    public class InvoiceControllerTests
    {
        private  InvoiceController invoiceController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MVPContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            var context = new MVPContext(options);
            var countryservice = new CountryService(context);
            var productService = new ProductService(context);

            countryservice.SetNewCountry(new Country() {Name = "Hungary", Tax = 27 });
            productService.SetNewProduct(new Product() { Name = "Apple", Price = 100 });
            productService.SetNewProduct(new Product() { Name = "Pizza", Price = 100 });

            invoiceController = new InvoiceController(new InvoiceDataHelper(countryservice, productService), new InvoiceCreatorHelper(), new EmailHelper(), new OrderHelper());
        }

        [Test]
        public void InvoiceController_OK()
        {
            var request = new InvoiceRequestDto() 
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Apple", Quantity = 2},
                    new ProductDto(){Name = "Pizza", Quantity = 3}
                },
                Country = "Hungary",
                InvoiceFormat = "JSON",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceController.Post(request);
            InvoiceResponseDto res = JsonConvert.DeserializeObject<InvoiceResponseDto>(response);

            Assert.AreEqual(res.TotalPrices, 635.0);
            Assert.AreEqual(res.TotalTaxes, 135.0);
        }

        [Test]
        public void InvoiceController_UnsupportedCountry()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Apple", Quantity = 2},
                    new ProductDto(){Name = "Pizza", Quantity = 3}
                },
                Country = "Poland",
                InvoiceFormat = "JSON",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceController.Post(request);

            Assert.IsTrue(response.Contains("Error: Poland country does not supported!"));
        }

        [Test]
        public void InvoiceController_UnsupportedProduct()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Car", Quantity = 2},
                    new ProductDto(){Name = "Pizza", Quantity = 3}
                },
                Country = "Hungary",
                InvoiceFormat = "JSON",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceController.Post(request);

            Assert.IsTrue(response.Contains("Error: Car product does not supported!"));
        }

        [Test]
        public void InvoiceController_WithoutProduct()
        {
            var request = new InvoiceRequestDto()
            {
                Country = "Hungary",
                InvoiceFormat = "JSON",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceController.Post(request);

            Assert.IsTrue(response.Contains("Error: Please give one or more products!"));
        }

        [Test]
        public void InvoiceController_WithoutEmail()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Apple", Quantity = 2},
                    new ProductDto(){Name = "Pizza", Quantity = 3}
                },
                Country = "Hungary",
                InvoiceFormat = "JSON",
                SendEmail = "true"
            };
            var response = invoiceController.Post(request);
            Assert.IsTrue(response.Contains("Error: Please give a valid Email Address!"));
        }

        [Test]
        public void InvoiceController_BadInvoiceFormat()
        {
            var request = new InvoiceRequestDto()
            {
                Products = new List<ProductDto>()
                {
                    new ProductDto(){Name = "Apple", Quantity = 2},
                    new ProductDto(){Name = "Pizza", Quantity = 3}
                },
                Country = "Hungary",
                InvoiceFormat = "TEST",
                SendEmail = "true",
                EmailAddress = "something@something.com"
            };
            var response = invoiceController.Post(request);

            Assert.IsTrue(response.Contains("Error: TEST invoice format does not supported!"));
        }
    }
}