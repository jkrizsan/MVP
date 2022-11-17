using Data;
using Data.Enums;
using Data.Models;
using Moq;
using NUnit.Framework;
using Services;
using Services.Abstractions;
using Services.DataModels;
using Services.Factories;
using Services.InvoiceBuilders;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class InvoiceCreatorServiceTest
    {
        private Mock<IMessageFactory> _messageFactoryMock;

        private Mock<IEmailService> _emailServiceMock;

        private Mock<IInvoiceRepository> _invoiceRepositoryMock;

        private Mock<IInvoiceBuilderFactory> _invoiceBuilderFactoryMock;

        private InvoiceManagerService _invoiceManagerService;

        private DateTime _dateTime;

        [SetUp]
        public void Setup()
        {
            _dateTime = DateTime.Now;

            _emailServiceMock = new Mock<IEmailService>();

            _invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            _invoiceRepositoryMock.Setup(x => x.GetInvoicesAsync(_dateTime, _dateTime.AddDays(1), 0, 1))
                .ReturnsAsync(new List<Invoice>());

            _messageFactoryMock = new Mock<IMessageFactory>();
            _messageFactoryMock.Setup(x => x.Create(new InvoiceResponse())).Returns(new InvoiceMessage(new InvoiceResponse()));

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<JsonInvoiceBuilder>()).Returns(new JsonInvoiceBuilder());

            SetupInvoiceCreatorService();
        }

        #region ManageInvoiceAsync

        [Test]
        public async Task ManageInvoiceAsync_JsonInvocieBuilder_Ok()
        {
            string testString = InvoiceFormat.JSON.ToString();

            InvoiceResponse response = CreateInvoiceResponse(InvoiceFormat.JSON);

            SetupMessageFactory(response, testString);

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<JsonInvoiceBuilder>())
                .Returns(new JsonInvoiceBuilder());

            SetupInvoiceCreatorService();

            string resp = await _invoiceManagerService.ManageInvoiceAsync(response);

            Assert.IsTrue(resp.Contains(testString));
        }

        [Test]
        public async Task ManageInvoiceAsync_HtmlInvocieBuilder_Ok()
        {
            string testString = InvoiceFormat.HTML.ToString();

            InvoiceResponse response = CreateInvoiceResponse(InvoiceFormat.HTML);

            SetupMessageFactory(response, testString);

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<HtmlInvoiceBuilder>())
                .Returns(new HtmlInvoiceBuilder());

            SetupInvoiceCreatorService();

            string resp = await _invoiceManagerService.ManageInvoiceAsync(response);

            Assert.IsTrue(resp.Contains(testString));
        }

        [Test]
        public void ManageInvoiceAsync_UnknownInvocieBuilder_Error()
        {
            string testString = InvoiceFormat.Unknown.ToString();

            InvoiceResponse response = CreateInvoiceResponse(InvoiceFormat.Unknown);

            SetupMessageFactory(response, testString);

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<HtmlInvoiceBuilder>())
                .Returns(new HtmlInvoiceBuilder());

            SetupInvoiceCreatorService();

            Exception ex = Assert.ThrowsAsync<Exception>(async () => await _invoiceManagerService.ManageInvoiceAsync(response));

            Assert.That(ex.Message, Is.EqualTo(Constants.InvalidInvoiceFormat));
        }

        #endregion ManageInvoiceAsync

        private void SetupInvoiceCreatorService()
        {
            _invoiceManagerService = new InvoiceManagerService(
                _messageFactoryMock.Object, _emailServiceMock.Object, _invoiceRepositoryMock.Object, _invoiceBuilderFactoryMock.Object);
        }

        private void SetupMessageFactory(InvoiceResponse response, string testString)
        {
            var mockInvoiceMessage = new Mock<InvoiceMessage>(response);
            mockInvoiceMessage.Setup(x => x.BuildAsync()).ReturnsAsync(testString);

            _messageFactoryMock = new Mock<IMessageFactory>();
            _messageFactoryMock.Setup(x => x.Create(response)).Returns(mockInvoiceMessage.Object);
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
