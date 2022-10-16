using MVP.Data.Models;

namespace MVP.Services.Repositories
{
    /// <summary>
    /// Interface of Country Repository
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Add New Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        bool Add(Country country);

        /// <summary>
        /// Get a Country by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Country</returns>
        Country GetById(int id);

        /// <summary>
        /// Get a Country by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Country</returns>
        Country GetByName(string name);

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="country"></param>
        void Delete(Country country);

        /// <summary>
        /// Remove Country By Name
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);
    }
}
