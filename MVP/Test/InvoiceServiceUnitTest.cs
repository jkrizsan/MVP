using Moq;
using Data.Enums;
using Data.Models;
using Services;
using Services.Abstractions;
using Services.DataModels;
using Services.Factories;
using NUnit.Framework;
using Services.InvoiceBuilders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Repositories;
using System.Globalization;
using Services.Exceptions;
using AutoMapper;
using Data;

namespace Tests
{
    class InvoiceServiceUnitTest
    {
        private InvoiceService _invoiceService;

        private Mock<IMessageFactory> _messageFactoryMock;

        private Mock<IInvoiceManagerService> _invoiceCreatorServiceMock;

        private Mock<IMapper> _mapperMock;

        private Mock<IInvoiceRepository> _invoiceRepositoryMock;

        private Mock<IInvoiceBuilderFactory> _invoiceBuilderFactoryMock;

        private DateTime _dateTime;

        [SetUp]
        public void Setup()
        {
             _dateTime = DateTime.Now;

             IEnumerable<Invoice> rawInvoices = new List<Invoice>();

            _invoiceCreatorServiceMock = new Mock<IInvoiceManagerService>();

            _mapperMock = new Mock<IMapper>();
            _mapperMock.Setup(x => x.Map<IEnumerable<Invoice>, IEnumerable<HistoryResponse>>(rawInvoices))
                .Returns(new List<HistoryResponse>() { new HistoryResponse() });

            _invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            _invoiceRepositoryMock.Setup(x => x.GetInvoicesAsync(_dateTime, _dateTime.AddDays(1), 0, 1))
                .ReturnsAsync(new List<Invoice>());

            _messageFactoryMock = new Mock<IMessageFactory>();
            _messageFactoryMock.Setup(x => x.Create(new InvoiceResponse())).Returns(new InvoiceMessage(new InvoiceResponse()));

            _invoiceBuilderFactoryMock = new Mock<IInvoiceBuilderFactory>();
            _invoiceBuilderFactoryMock.Setup(x => x.Create<JsonInvoiceBuilder>()).Returns(new JsonInvoiceBuilder());

            SetupInvoiceCreatorService();
        }

        [Test]
        public async Task GetInvoicesAsync_GoodRequestWithUnknownInvoiceFormat_Ok()
        {
            HistoryRequest req = new HistoryRequest()
            {
                Start = _dateTime.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                End = _dateTime.AddDays(1).ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                Skip = 0,
                Take = 1,
                InvoiceFormat = InvoiceFormat.Unknown
            }; 

            List<HistoryResponse> resp = await _invoiceService.GetInvoicesAsync(req);

            Assert.IsTrue(resp.Count == 1); 
        }

        [Test]
        public async Task GetInvoicesAsync_GoodRequestWithJSONInvoiceFormat_Ok()
        {
            HistoryRequest req = new HistoryRequest()
            {
                Start = _dateTime.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                End = _dateTime.AddDays(1).ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                Skip = 0,
                Take = 1,
                InvoiceFormat = InvoiceFormat.JSON
            };

            List<HistoryResponse> resp = await _invoiceService.GetInvoicesAsync(req);

            Assert.IsTrue(resp.Count == 1);
        }

        [Test]
        public async Task GetInvoicesAsync_RequestParamIsNull_Error()
        {
            Exception ex = Assert.ThrowsAsync<NullReferenceException>(async ()
                => await _invoiceService.GetInvoicesAsync(null));

            Assert.That(ex.Message, Is.EqualTo(Constants.GetString(Constants.NullreferenceException, "request")));
            Assert.That(ex.Message, Is.EqualTo(Constants.GetString(Constants.NullreferenceException, "request")));
        }

        [Test]
        public async Task GetInvoicesAsync_StartParamIsUnset_Error()
        {
            HistoryRequest req = new HistoryRequest()
            {
                End = _dateTime.AddDays(1).ToString(new CultureInfo("en-US")),
                Skip = 0,
                Take = 1
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async ()
                => await _invoiceService.GetInvoicesAsync(req));

            Assert.That(ex.ErrorMessage, Is.EqualTo(Constants.GetString(Constants.InvalidDate, "Start")));
        }

        [Test]
        public async Task GetInvoicesAsync_EndParamIsUnset_Error()
        {
            HistoryRequest req = new HistoryRequest()
            {
                Start = _dateTime.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                Skip = 0,
                Take = 1
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async ()
                => await _invoiceService.GetInvoicesAsync(req));

            Assert.That(ex.ErrorMessage, Is.EqualTo(Constants.GetString(Constants.InvalidDate, "End")));
        }

        [Test]
        public async Task GetInvoicesAsync_EndIsEarlierThenStart_Error()
        {
            HistoryRequest req = new HistoryRequest()
            {
                Start = _dateTime.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                End = _dateTime.AddDays(-1).ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                Skip = 0,
                Take = 1
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async ()
                => await _invoiceService.GetInvoicesAsync(req));

            Assert.That(ex.ErrorMessage,
                Is.EqualTo(Constants.GetString(Constants.TimelineValidation, "Start", "End")));
        }

        [Test]
        public async Task GetInvoicesAsync_SkipIsNegative_Error()
        {
            HistoryRequest req = new HistoryRequest()
            {
                Start = _dateTime.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                End = _dateTime.AddDays(1).ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                Skip = -1,
                Take = 1
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async ()
                => await _invoiceService.GetInvoicesAsync(req));

            Assert.That(ex.ErrorMessage,
                Is.EqualTo(Constants.GetString(Constants.MustBePositive, "Skip")));
        }

        [Test]
        public async Task GetInvoicesAsync_TakeIsZero_Error()
        {
            HistoryRequest req = new HistoryRequest()
            {
                Start = _dateTime.ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                End = _dateTime.AddDays(1).ToString(Constants.TimeFormat, CultureInfo.InvariantCulture),
                Skip = 0,
                Take = 0
            };

            ValidationException ex = Assert.ThrowsAsync<ValidationException>(async ()
                => await _invoiceService.GetInvoicesAsync(req));

            Assert.That(ex.ErrorMessage,
                Is.EqualTo(Constants.GetString(Constants.MustBeAtLeastOne, "Take")));
        }

        private void SetupInvoiceCreatorService()
        {
            _invoiceService = new InvoiceService(
                _mapperMock.Object, _invoiceRepositoryMock.Object, _invoiceCreatorServiceMock.Object);
        }
    }
}
