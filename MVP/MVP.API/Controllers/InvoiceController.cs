using System;
using Microsoft.AspNetCore.Mvc;
using MVP.Data.DTOs;
using MVP.Services;

namespace MVP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IEmailService _emailService;
        private readonly IOrderService _orderService;

        public InvoiceController(
            IInvoiceService invoiceService,
            IEmailService emailService,
            IOrderService orderService)
        {
            _invoiceService = invoiceService;
            _emailService = emailService;
            _orderService = orderService;
        }

        /// <summary>
        /// Create Invoice
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Invoice
        ///     {
        ///        "Country": "Finland",
        ///        "InvoiceFormat" : "JSON",
        ///        "SendEmail": "true",
        ///        "EmailAddress": "xyz@abc.com",
        ///        "Products":
        ///       [
        ///        {"Name": "apple", "Quantity":1}
        ///       ]
        ///     }
        ///
        [HttpPost]
        public string Post([FromBody]InvoiceRequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException(nameof(requestDto));
            }

            InvoiceResponseDto responseDto = _invoiceService.CheckAndParseInvoice(requestDto);
            if(responseDto.ErrorMessage?.Length > 0)
            {
                return responseDto.ErrorMessage;
            }

            var response = _invoiceService.CreateInvoice(responseDto);

            if (responseDto.SendEmail)
            {
                _emailService.SendMail(response, responseDto.EmailAddress);
            }

            return response;
        }
    }
}
