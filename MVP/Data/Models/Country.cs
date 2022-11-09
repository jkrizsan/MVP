using System;

namespace MVP.Data.Models
{
    /// <summary>
    /// Country
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tax rate in the country
        /// </summary>
        public double Tax { get; set; }

        public Country()
        {
            Id = Guid.NewGuid();
        }
    }
}
