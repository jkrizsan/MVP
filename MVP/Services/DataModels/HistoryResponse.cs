using Data.Enums;
using System;

namespace Services.DataModels
{
    /// <summary>
    /// Data class for invoice history response
    /// </summary>
    public class HistoryResponse
    {
        /// <summary>
        /// Date when the invoice was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Invoice format
        /// </summary>
        public InvoiceFormat? InvoiceFormat { get; init; }

        /// <summary>
        /// Content of the Invoice
        /// </summary>
        public string Content { get; set; }
    }
}
