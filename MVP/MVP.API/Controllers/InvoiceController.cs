using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVP.Services.Exceptions;
using MVP.Services.DataModels;
using MVP.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post([FromBody]InvoiceRequest request)
        {
            try
            {
                InvoiceResponse invoiceResponse = await _invoiceProcessorService.ValidateAndMapInvoiceAsync(request);

                var response = await _invoiceService.ManageInvoiceAsync(invoiceResponse);

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
