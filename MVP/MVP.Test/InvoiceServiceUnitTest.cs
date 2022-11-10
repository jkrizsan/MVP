﻿using Moq;
using MVP.Data.Enums;
using MVP.Data.Models;
using MVP.Services;
using MVP.Services.Abstractions;
using MVP.Services.DataModels;
using MVP.Services.Factories;
using NUnit.Framework;
using Services.InvoiceBuilders;
using System;
using System.Collections.Generic;

namespace MVP.Test
{
    class InvoiceServiceUnitTest
    {
        private InvoiceService _invoiceService;

        private Mock<IMessageFactory> _messageFactoryMock;

        private Mock<IEmailService> _emailServiceMock;

        private Mock<IInvoiceBuilderFactory> _invoiceBuilderFactoryMock;

        [SetUp]
        public void Setup()
        {
            _emailServiceMock = new Mock<IEmailService>();

            _messageFactoryMock = new Mock<IMessageFactory>();
            _messageFactoryMock.Setup(x => x.Create(new InvoiceResponse())).Returns(new InvoiceMessage(new InvoiceResponse()));

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<JsonInvoiceBuilder>()).Returns(new JsonInvoiceBuilder());

            SetupInvoiceService();
        }
 
        [Test]
        public void CreateInvoice_JsonInvocieBuilder_Ok()
        {
            string testString = "JSON";

            InvoiceResponse response = CreateInvoiceResponse(InvoiceFormat.JSON);

            SetupMessageFactory(response, testString);

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<JsonInvoiceBuilder>())
                .Returns(new JsonInvoiceBuilder());

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

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<HtmlInvoiceBuilder>())
                .Returns(new HtmlInvoiceBuilder());

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

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<HtmlInvoiceBuilder>())
                .Returns(new HtmlInvoiceBuilder());

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
            _invoiceService = new InvoiceService(_messageFactoryMock.Object, _emailServiceMock.Object, _invoiceBuilderFactoryMock.Object);
        }

        private InvoiceResponse CreateInvoiceResponse(InvoiceFormat invoiceFormat)
        {
            return new InvoiceResponse()
            {
                InvoiceFormat = invoiceFormat,
                Country = new Country() { Id = Guid.NewGuid(), Name = "Hungary", Tax = 27 },
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
