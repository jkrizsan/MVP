using System;
using System.Linq;
using MVP.Data;
using MVP.Data.Models;

namespace MVP.Services
{
    public class ProductService : IProductService
    {
        MVPContext context;

        #region Constructor
        public ProductService(MVPContext context)
        {
            this.context = context;
        }
        #endregion Constructor

        #region Get

        /// <inheritdoc />
        public Product GetProductById(int id)
        {
            return context.Products.Where(p => p.Id.Equals(id)).SingleOrDefault();
        }

        /// <inheritdoc />
        public Product GetProductByName(string name)
        {
            return context.Products.Where(p => p.Name.Equals(name)).SingleOrDefault();
        }

        #endregion Get

        #region Remove

        /// <inheritdoc />
        public void RemoveProduct(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            } 

            context.Products.Remove(product);
            context.SaveChanges();
        }

        /// <inheritdoc />
        public void RemoveProductById(int id)
        {
            var product = GetProductById(id);
            RemoveProduct(product);
        }

        #endregion Remove

        #region Set

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

            context.Products.Add(product);
            context.SaveChanges();
            return true;
        }

        #endregion Set
    }
}
