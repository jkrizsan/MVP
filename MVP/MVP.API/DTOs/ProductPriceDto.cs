﻿using MVP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.API.DTOs
{
    public class ProductPriceDto
    {
        public Product Product { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }

        public ProductPriceDto(Product product)
        {
            Product = product;
        }
    }
}