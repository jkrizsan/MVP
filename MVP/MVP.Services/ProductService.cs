using System;
using System.Linq;
using MVP.Data;
using MVP.Data.Models;

namespace MVP.Services
{
    /// <summary>
    /// Product Service
    /// </summary>
    public class ProductService : IProductService
    {
        private MVPContext _context;

        public ProductService(MVPContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Product GetProductById(int id)
        {
            return _context.Products.Where(p => p.Id.Equals(id)).SingleOrDefault();
        }

        /// <inheritdoc />
        public Product GetProductByName(string name)
        {
            return _context.Products.Where(p => p.Name.Equals(name)).SingleOrDefault();
        }

        /// <inheritdoc />
        public void RemoveProduct(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            } 

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void RemoveProductById(int id)
        {
            var product = GetProductById(id);
            RemoveProduct(product);
        }

        /// <inheritdoc />
        public bool SetNewProduct(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var prod = GetProductByName(product.Name);

            if(prod != null)
            {
                return false;
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }

    }
}
