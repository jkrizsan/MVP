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
        public int Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tax rate in the country
        /// </summary>
        public double Tax { get; set; }
    }
}
