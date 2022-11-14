using Data.Enums;
using System;

namespace Data.Models
{
    /// <summary>
    /// Invoice data class
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Invoice type
        /// </summary>
        public InvoiceFormat InvoiceFormat { get; set; }

        /// <summary>
        /// Date when the invoice was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Content of the Invoice
        /// </summary>
        public string Content { get; set; }

        public Invoice()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
