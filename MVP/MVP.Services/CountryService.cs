﻿using MVP.Data;
using MVP.Data.Models;
using System;
using System.Linq;

namespace MVP.Services
{
    public class CountryService : ICountryService
    {
        MVPContext context;

        #region Constructor
        public CountryService(MVPContext context)
        {
            this.context = context;
        }
        #endregion Constructor

        #region Get

        public Country GetCountryById(int id)
        {
            return context.Countries.Where(p => p.Id.Equals(id)).SingleOrDefault();
        }

        public Country GetCountryByName(string name)
        {
            return context.Countries.Where(p => p.Name.Equals(name)).SingleOrDefault();
        }

        #endregion Get

        #region Remove

        public void RemoveCountry(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            context.Countries.Remove(country);
            context.SaveChanges();
        }

        public void RemoveCountryById(int id)
        {
            var country = GetCountryById(id);
            RemoveCountry(country);
        }

        #endregion Remove

        #region Set

        public bool SetNewCountry(Country country)
        {
            if (country is null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            var count = GetCountryByName(country.Name);

            if (count != null)
            {
                return false;
            }

            context.Countries.Add(country);
            context.SaveChanges();
            return true;
        }

        #endregion Set
    }
}
