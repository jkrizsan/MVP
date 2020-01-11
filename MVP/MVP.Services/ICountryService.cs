using MVP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVP.Services
{
    interface ICountryService
    {
        bool SetNewCountry(Country country);
        Product GetCountryById(int id);
        Product GetCountryByName(string name);
        void RemoveCountry(Country country);
        void RemoveCountryById(int id);
    }
}
