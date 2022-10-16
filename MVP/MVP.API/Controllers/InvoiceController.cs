using Microsoft.AspNetCore.Mvc;
using MVP.Data.Models;
using MVP.Services;
using MVP.Services.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVP.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IEmailService _emailService;

        public InvoiceController(
            IInvoiceService invoiceService,
            IEmailService emailService)
        {
            _invoiceService = invoiceService;
            _emailService = emailService;
        }

        // POST: invoice
        [HttpPost]
        public ActionResult Post([FromBody]InvoiceRequest request)
        {
            try
            {
                InvoiceResponse invoiceResponse = _invoiceService.CheckAndParseInvoice(request);

                if (invoiceResponse.ErrorMessage?.Length > 0)
                {
                    return ValidationProblem(invoiceResponse.ErrorMessage);
                }

                var response = _invoiceService.CreateInvoice(invoiceResponse);

                if (invoiceResponse.SendEmail)
                {
                    _emailService.SendMail(response, invoiceResponse.EmailAddress);
                }

                return Ok(response);
            }
            catch(ValidationException ex)
            {
                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
