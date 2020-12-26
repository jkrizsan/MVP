using MVP.Data.Models;

namespace MVP.Services
{
    public interface ICountryService
    {
        bool SetNewCountry(Country country);
        Country GetCountryById(int id);
        Country GetCountryByName(string name);
        void RemoveCountry(Country country);
        void RemoveCountryById(int id);
    }
}
