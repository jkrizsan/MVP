using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IInvoiceRepository
    {
        /// <summary>
        /// Insert new Invoice to the DB
        /// </summary>
        /// <param name="invoiceFormat"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task AddAsync(InvoiceFormat invoiceFormat, string content);

        /// <summary>
        /// Receive a list of previously created invoices
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<IEnumerable<Invoice>> GetInvoicesAsync(DateTime startTime, DateTime endTime, int skip = 0, int take = 100);
    }
}
