﻿using MVP.Services.DataModels;

namespace MVP.Services
{
    /// <summary>
    /// Interface of the InvoiceProcessorService
    /// </summary>
    public interface IInvoiceProcessorService
    {
        /// <summary>
        /// Validate and map invoice request data
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        InvoiceResponse ValidateAndMapInvoice(InvoiceRequest requestDto);
    }
}
