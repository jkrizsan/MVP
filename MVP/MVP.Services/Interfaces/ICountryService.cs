using MVP.Data.Models;

namespace MVP.Services
{
    /// <summary>
    /// Interface of Country Service
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Add New Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        bool SetNewCountry(Country country);

        /// <summary>
        /// Get a Country by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Country</returns>
        Country GetCountryById(int id);

        /// <summary>
        /// Get a Country by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Country</returns>
        Country GetCountryByName(string name);

        /// <summary>
        /// Remove Coiuntry
        /// </summary>
        /// <param name="country"></param>
        void RemoveCountry(Country country);

        /// <summary>
        /// Remove Country By Name
        /// </summary>
        /// <param name="id"></param>
        void RemoveCountryById(int id);
    }
}
