using MVP.Data;
using MVP.Data.Models;
using System;
using System.Linq;

namespace MVP.Services
{
    /// <summary>
    /// Country Service
    /// </summary>
    public class CountryService : ICountryService
    {
        MVPContext _context;

        public CountryService(MVPContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Country GetCountryById(int id)
        {
            return _context.Countries
                .Where(p => p.Id.Equals(id))
                .SingleOrDefault();
        }

        /// <inheritdoc />
        public Country GetCountryByName(string name)
        {
            return _context.Countries
                .Where(p => p.Name.Equals(name))
                .SingleOrDefault();
        }

        /// <inheritdoc />
        public void RemoveCountry(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void RemoveCountryById(int id)
        {
            var country = GetCountryById(id);
            RemoveCountry(country);
        }

        /// <inheritdoc />
        public bool SetNewCountry(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            if (GetCountryByName(country.Name) != null)
            {
                return false;
            }

            _context.Countries.Add(country);
            _context.SaveChanges();
            return true;
        }
    }
}
