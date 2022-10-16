using MVP.Data.Models;

namespace MVP.Services.Repositories
{
    /// <summary>
    /// Interface of the Product Repository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Add new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool Add(Product product);

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        Product GetById(int id);

        /// <summary>
        /// Get Product by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Product</returns>
        Product GetByName(string name);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="product"></param>
        void Delete(Product product);

        /// <summary>
        /// Remove Product by Id
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);
    }
}
