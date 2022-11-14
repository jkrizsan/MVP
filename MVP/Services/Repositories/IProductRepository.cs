using Data.Models;
using System.Threading.Tasks;

namespace Services.Repositories
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
        Task<bool> AddAsync(Product product);

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        Task<Product> GetByIdAsync(int id);

        /// <summary>
        /// Get Product by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Product</returns>
        Task<Product> GetByNameAsync(string name);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="product"></param>
        Task DeleteAsync(Product product);

        /// <summary>
        /// Remove Product by Id
        /// </summary>
        /// <param name="id"></param>
        Task DeleteByIdAsync(int id);
    }
}
