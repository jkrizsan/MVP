using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVP.API.DTOs;
using MVP.API.Helpers;
using MVP.Services;

namespace MVP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> logger;
        private readonly IInvoiceDataHelper invoiceDataHelper;
        private readonly IInvoiceCreatorHelper invoiceCreatorHelper;
        private readonly IEmailHelper emailHelper;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceDataHelper invoiceDataHelper, IInvoiceCreatorHelper invoiceCreatorHelper, IEmailHelper emailHelper)
        {
            this.logger = logger;
            this.invoiceDataHelper = invoiceDataHelper;
            this.invoiceCreatorHelper = invoiceCreatorHelper;
            this.emailHelper = emailHelper;
        }

        [HttpGet]
        public IEnumerable<InvoiceRequestDto> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new InvoiceRequestDto
            {
                Country = "Finland"
            })
            .ToArray();
        }

        [HttpPost]
        public string Post([FromBody]InvoiceRequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException($"Method name: {nameof(Post)}");
            }
            InvoiceResponseDto responseDto = invoiceDataHelper.CheckAndParseInvoice(requestDto);
            if(responseDto.ErrorMessage?.Length > 0)
            {
                return responseDto.ErrorMessage;
            }

            var response = invoiceCreatorHelper.CreateInvoice(responseDto);

            if (responseDto.SendEmail)
            {
                emailHelper.SendMail(response, responseDto.EmailAddress);
            }

            return response; // invoice.Temperature.ToString();
        }
    }
}
