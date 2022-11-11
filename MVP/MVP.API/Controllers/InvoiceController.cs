using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVP.Services.Exceptions;
using MVP.Services.DataModels;
using MVP.Services;
using Microsoft.AspNetCore.Authorization;

namespace MVP.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        private readonly IInvoiceProcessorService _invoiceProcessorService;

        public InvoiceController(
            IInvoiceService invoiceService,
            IInvoiceProcessorService invoiceProcessorService)
        {
            _invoiceService = invoiceService;
            _invoiceProcessorService = invoiceProcessorService;
        }

        // POST: invoice
        [HttpPost]
        public ActionResult Post([FromBody]InvoiceRequest request)
        {
            try
            {
                InvoiceResponse invoiceResponse = _invoiceProcessorService.ValidateAndMapInvoice(request);

                var response = _invoiceService.CreateInvoice(invoiceResponse);

                _invoiceService.SendInvoiceViaEmail(response, invoiceResponse);

                return Ok(response);
            }
            catch(ValidationException ex)
            {
                return BadRequest($"Validation error: {ex.ErrorMessage}");
            }
            catch (EmailException ex)
            {
                return Problem($"Email error: {ex.ErrorMessage}");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
        }
    }
}
