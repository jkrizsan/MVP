using System;
using System.Linq;
using MVP.Data;
using MVP.Data.Models;

namespace MVP.Services.Repositories
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
        public Product GetById(int id)
        {
            return _context.Products
                .Where(p => p.Id.Equals(id))
                .SingleOrDefault();
        }

        /// <inheritdoc />
        public Product GetByName(string name)
        {
            return _context.Products
                .Where(p => p.Name.Equals(name))
                .SingleOrDefault();
        }

        /// <inheritdoc />
        public void Delete(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void DeleteById(int id)
        {
            var product = GetById(id);
            Delete(product);
        }

        /// <inheritdoc />
        public bool Add(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var prod = GetByName(product.Name);

            if (prod != null)
            {
                return false;
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }
    }
}
