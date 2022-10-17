using Moq;
using MVP.Data.Enums;
using MVP.Data.Exceptions;
using MVP.Data.Models;
using MVP.Services;
using MVP.Services.Abstractions;
using MVP.Services.Factories;
using MVP.Services.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MVP.Test
{
    class InvoiceServiceUnitTest
    {
        private InvoiceService _invoiceService;

        private Mock<ICountryRepository> _countryRepositoryMock;

        private Mock<IProductRepository> _productRepositoryMock;

        private Mock<IMessageFactory> _messageFactoryMock;

        private Mock<IInvoiceBuilderServiceFactory> _invoiceBuilderServiceFactoryMock;

        [SetUp]
        public void Setup()
        {
            _countryRepositoryMock = new Mock<ICountryRepository>();
            _countryRepositoryMock.Setup(x => x.GetByName("Hungary")).Returns(new Country() {Name = "Hungary", Tax = 27 });

            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(x => x.GetByName("Apple")).Returns(new Product() { Name = "Apple", Price = 100 });

            _messageFactoryMock = new Mock<IMessageFactory>();
            _messageFactoryMock.Setup(x => x.Create(new InvoiceResponse())).Returns(new InvoiceMessage(new InvoiceResponse()));

            _invoiceBuilderServiceFactoryMock = new Mock<IInvoiceBuilderServiceFactory>();
            _invoiceBuilderServiceFactoryMock.Setup(x => x.Create<JsonInvoiceBuilderService>()).Returns(new JsonInvoiceBuilderService());

            SetupInvoiceService();
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

            var response = _invoiceService.CheckAndParseInvoice(request);

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

            Assert.Throws<ValidationException>(() => _invoiceService.CheckAndParseInvoice(request), $"Error: {request.Country} country does not supported!");
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

            Assert.Throws<ValidationException>(() => _invoiceService.CheckAndParseInvoice(request), $"Error: {request.Products[0].Name} product does not supported!");
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

            Assert.Throws<ValidationException>(() => _invoiceService.CheckAndParseInvoice(request), "Error: Please give one or more products!");
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

            Assert.Throws<ValidationException>(() => _invoiceService.CheckAndParseInvoice(request), "Email Address is invalid!");
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

            Assert.Throws<ValidationException>(() => _invoiceService.CheckAndParseInvoice(request), $"InvoiceFormat is invalid!");
        }

        [Test]
        public void CreateInvoice_JsonInvocieBuilder_Ok()
        {
            string testString = "JSON";

            InvoiceResponse response = CreateInvoiceResponse(InvoiceFormat.JSON);

            SetupMessageFactory(response, testString);

            _invoiceBuilderServiceFactoryMock = new Mock<IInvoiceBuilderServiceFactory>();
            _invoiceBuilderServiceFactoryMock.Setup(x => x.Create<JsonInvoiceBuilderService>())
                .Returns(new JsonInvoiceBuilderService());

            SetupInvoiceService();

            string resp = _invoiceService.CreateInvoice(response);

            Assert.IsTrue(resp.Contains(testString));
        }

        [Test]
        public void CreateInvoice_HtmlInvocieBuilder_Ok()
        {
            string testString = "HTML";

            InvoiceResponse response = CreateInvoiceResponse(InvoiceFormat.HTML);

            SetupMessageFactory(response, testString);

            _invoiceBuilderServiceFactoryMock = new Mock<IInvoiceBuilderServiceFactory>();
            _invoiceBuilderServiceFactoryMock.Setup(x => x.Create<HtmlInvoiceBuilderService>())
                .Returns(new HtmlInvoiceBuilderService());

            SetupInvoiceService();

            string resp = _invoiceService.CreateInvoice(response);

            Assert.IsTrue(resp.Contains(testString));
        }

        [Test]
        public void CreateInvoice_UnknownInvocieBuilder_Error()
        {
            string testString = "Unknown";

            InvoiceResponse response = CreateInvoiceResponse(InvoiceFormat.Unknown);

            SetupMessageFactory(response, testString);

            _invoiceBuilderServiceFactoryMock = new Mock<IInvoiceBuilderServiceFactory>();
            _invoiceBuilderServiceFactoryMock.Setup(x => x.Create<HtmlInvoiceBuilderService>())
                .Returns(new HtmlInvoiceBuilderService());

            SetupInvoiceService();

            Assert.Throws<Exception>(() => _invoiceService.CreateInvoice(response), "Unexpected invoice format!");
        }

        private void SetupMessageFactory(InvoiceResponse response, string testString)
        {
            var mockInvoiceMessage = new Mock<InvoiceMessage>(response);
            mockInvoiceMessage.Setup(x => x.Build()).Returns(testString);

            _messageFactoryMock = new Mock<IMessageFactory>();
            _messageFactoryMock.Setup(x => x.Create(response)).Returns(mockInvoiceMessage.Object);
        }

        private void SetupInvoiceService()
        {
            _invoiceService = new InvoiceService(_countryRepositoryMock.Object, _productRepositoryMock.Object, _messageFactoryMock.Object, _invoiceBuilderServiceFactoryMock.Object);
        }

        private InvoiceResponse CreateInvoiceResponse(InvoiceFormat invoiceFormat)
        {
            return new InvoiceResponse()
            {
                InvoiceFormat = invoiceFormat,
                Country = new Country() { Id = 1, Name = "Hungary", Tax = 27 },
                SendEmail = true,
                EmailAddress = "XYZ@ABC.COM",
                TotalPrices = 124.0,
                TotalTaxes = 24.0,
                ProductPricess = new List<ProductPrice>()
                {
                    new ProductPrice()
                    {
                        Name = "Apple",
                        Price = 124.0,
                        Tax = 24.0
                    }
                }
            };
        }
    }
}
