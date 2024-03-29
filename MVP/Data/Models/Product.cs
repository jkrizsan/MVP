﻿
using System;

namespace Data.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Primery Key
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        public double Price { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}