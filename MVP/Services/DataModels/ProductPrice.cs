﻿namespace Services.DataModels
{
    /// <summary>
    /// Dto class for Product Price
    /// </summary>
    public class ProductPrice
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
        /// Tax on the product
        /// </summary>
        public double Tax { get; set; }
    }
}
