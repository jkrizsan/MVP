using Data;
using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        MVPContext _context;

        public InvoiceRepository(MVPContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task AddAsync(InvoiceFormat invoiceFormat, string content)
        {
            Invoice invoice = new Invoice()
            {
                Content = content,
                InvoiceFormat = invoiceFormat
            };

            _context.Invoices.Add(invoice);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Invoice>> GetInvoicesAsync(DateTime startTime, DateTime endTime, int skip = 0, int take = 100)
        {
            return await _context.Invoices
                .Where(x => x.CreatedAt >= startTime && x.CreatedAt <= endTime)
                .Skip(skip)
                .Take(take)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
