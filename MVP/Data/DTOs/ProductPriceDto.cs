namespace MVP.Data.DTOs
{
    /// <summary>
    /// Dto class for Product Price
    /// </summary>
    public class ProductPriceDto
    {
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Product Tax
        /// </summary>
        public double Tax { get; set; }
    }
}
