using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVP.Data.Exceptions;
using MVP.Data.Models;
using MVP.Services;
using MVP.Services.Repositories;
using System;

namespace MVP.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        private readonly IInvoiceProcessorService _invoiceProcessorService;

        private readonly IEmailService _emailService;

        public InvoiceController(
            IInvoiceService invoiceService,
            IInvoiceProcessorService invoiceProcessorService,
            IEmailService emailService)
        {
            _invoiceService = invoiceService;
            _invoiceProcessorService = invoiceProcessorService;
            _emailService = emailService;
        }

        // POST: invoice
        [HttpPost]
        public ActionResult Post([FromBody]InvoiceRequest request)
        {
            try
            {
                InvoiceResponse invoiceResponse = _invoiceProcessorService.CheckAndParseInvoice(request);

                var response = _invoiceService.CreateInvoice(invoiceResponse);

                if (invoiceResponse.SendEmail)
                {
                    _emailService.SendMail(response, invoiceResponse.EmailAddress);
                }

                return Ok(response);
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError("Validation Error", ex.ErrorMessage);
                return BadRequest(ModelState);
            }
            catch (EmailException ex)
            {
                ModelState.AddModelError("Email Error", ex.ErrorMessage);
                return BadRequest(ModelState);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }
    }
}
