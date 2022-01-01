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
        private readonly IInvoiceService invoiceService;
        private readonly IEmailService emailService;
        private readonly IOrderService orderService;

        public InvoiceController(
            IInvoiceService invoiceService,
            IEmailService emailService,
            IOrderService orderService)
        {
            this.invoiceService = invoiceService;
            this.emailService = emailService;
            this.orderService = orderService;
        }

        [HttpPost]
        public string Post([FromBody]InvoiceRequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException(nameof(requestDto));
            }

            InvoiceResponseDto responseDto = invoiceService.CheckAndParseInvoice(requestDto);
            if(responseDto.ErrorMessage?.Length > 0)
            {
                return responseDto.ErrorMessage;
            }

            var response = invoiceService.CreateInvoice(responseDto);

            if (responseDto.SendEmail)
            {
                emailService.SendMail(response, responseDto.EmailAddress);
            }

            return response;
        }
    }
}
