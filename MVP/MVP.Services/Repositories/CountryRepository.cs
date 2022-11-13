using Microsoft.EntityFrameworkCore;
using MVP.Data;
using MVP.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries
                .Where(p => p.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task<Country> GetByNameAsync(string name)
        {
            return await _context.Countries
                .Where(p => p.Name.Equals(name))
                .SingleOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            _context.Countries.Remove(country);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteByIdAsync(int id)
        {
            var country = await GetByIdAsync(id);
            await DeleteAsync(country);
        }

        /// <inheritdoc />
        public async Task<bool> AddAsync(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            if (await GetByNameAsync(country.Name) != null)
            {
                return false;
            }

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
