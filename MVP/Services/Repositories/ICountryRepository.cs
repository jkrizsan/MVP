using Data.Models;
using System.Threading.Tasks;

namespace Services.Repositories
{
    /// <summary>
    /// Interface of the Country Repository
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Add New Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<bool> AddAsync(Country country);

        /// <summary>
        /// Get a Country by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Country</returns>
        Task<Country> GetByIdAsync(int id);

        /// <summary>
        /// Get a Country by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Country</returns>
        Task<Country> GetByNameAsync(string name);

        /// <summary>
        /// Delete a Country
        /// </summary>
        /// <param name="country"></param>
        Task DeleteAsync(Country country);

        /// <summary>
        /// Remove a Country By Name
        /// </summary>
        /// <param name="id"></param>
        Task DeleteByIdAsync(int id);
    }
}
