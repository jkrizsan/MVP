using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;

namespace Services.Repositories
{
    /// <summary>
    /// Product Repository
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private MVPContext _context;

        public ProductRepository(MVPContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Where(p => p.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task<Product> GetByNameAsync(string name)
        {
            return await _context.Products
                .Where(p => p.Name.Equals(name))
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteByIdAsync(int id)
        {
            var product = await GetByIdAsync(id);
            await DeleteAsync(product);
        }

        /// <inheritdoc />
        public async Task<bool> AddAsync(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var prod = await GetByNameAsync(product.Name);

            if (prod != null)
            {
                return false;
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
