using System;
using Microsoft.AspNetCore.Mvc;
using MVP.API.Helpers;

namespace MVP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceDataHelper invoiceDataHelper;
        private readonly IInvoiceCreatorHelper invoiceCreatorHelper;
        private readonly IEmailHelper emailHelper;
        private readonly IOrderHelper orderHelper;

        public InvoiceController( IInvoiceDataHelper invoiceDataHelper, IInvoiceCreatorHelper invoiceCreatorHelper, IEmailHelper emailHelper, IOrderHelper orderHelper)
        {
            this.invoiceDataHelper = invoiceDataHelper;
            this.invoiceCreatorHelper = invoiceCreatorHelper;
            this.emailHelper = emailHelper;
            this.orderHelper = orderHelper;
        }

        [HttpPost]
        public string Post([FromBody]InvoiceRequestDto requestDto)
        {
            if (requestDto is null)
            {
                throw new ArgumentNullException($"Method name: {nameof(requestDto)}");
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

            return response;
        }
    }
}
