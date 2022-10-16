using MVP.Data;
using MVP.Data.Models;
using System;
using System.Linq;

namespace MVP.Services.Repositories
{
    /// <summary>
    /// Country Repository
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        MVPContext _context;

        public CountryRepository(MVPContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Country GetById(int id)
        {
            return _context.Countries
                .Where(p => p.Id.Equals(id))
                .SingleOrDefault();
        }

        /// <inheritdoc />
        public Country GetByName(string name)
        {
            return _context.Countries
                .Where(p => p.Name.Equals(name))
                .SingleOrDefault();
        }

        /// <inheritdoc />
        public void Delete(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void DeleteById(int id)
        {
            var country = GetById(id);
            Delete(country);
        }

        /// <inheritdoc />
        public bool Add(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            if (GetByName(country.Name) != null)
            {
                return false;
            }

            _context.Countries.Add(country);
            _context.SaveChanges();
            return true;
        }
    }
}
