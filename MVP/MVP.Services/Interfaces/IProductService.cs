using MVP.Data.Models;

namespace MVP.Services
{
    /// <summary>
    /// Interface for Product Service
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Add new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool SetNewProduct(Product product );

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        Product GetProductById(int id);

        /// <summary>
        /// Get Product by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Product</returns>
        Product GetProductByName(string name);

        /// <summary>
        /// Remove Product
        /// </summary>
        /// <param name="product"></param>
        void RemoveProduct(Product product);

        /// <summary>
        /// Remove Product by Id
        /// </summary>
        /// <param name="id"></param>
        void RemoveProductById(int id);
    }
}
