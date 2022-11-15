using Microsoft.EntityFrameworkCore;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Data.Authentication;
using System.Linq;
using System.Collections.Generic;

namespace Data
{
    internal class SeedData
    {
       
        public static void Initialize(ModelBuilder modelBuilder)
        {


            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Name = UserRoles.User,
            //    NormalizedName = UserRoles.User.ToUpperInvariant(),
            //});

            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Name = UserRoles.Admin,
            //    NormalizedName = UserRoles.Admin.ToUpperInvariant(),
            //});

            modelBuilder.Entity<Product>()
              .HasData(
                new Product() { Name = "Apple", Price = 100 },
                new Product() { Name = "Banana", Price = 199 },
                new Product() { Name = "Car", Price = 9990.5 },
                new Product() { Name = "Pizza", Price = 30 },
                new Product() { Name = "Eggs", Price = 24 });

            modelBuilder.Entity<Country>()
              .HasData(
                new Country() { Name = "Austria", Tax = 20 },
                new Country() { Name = "Belgium", Tax = 21 },
                new Country() { Name = "Bulgaria", Tax = 20 },
                new Country() { Name = "Cyprus", Tax = 19 },
                new Country() { Name = "Czech Republic", Tax = 21 },
                new Country() { Name = "Croatia", Tax = 25 },
                new Country() { Name = "Denmark", Tax = 25 },
                new Country() { Name = "Estonia", Tax = 20 },
                new Country() { Name = "Finland", Tax = 24 },
                new Country() { Name = "France", Tax = 20 },
                new Country() { Name = "Germany", Tax = 19 },
                new Country() { Name = "Greece", Tax = 24 },
                new Country() { Name = "Hungary", Tax = 27 },
                new Country() { Name = "Ireland", Tax = 23 },
                new Country() { Name = "Italy", Tax = 22 },
                new Country() { Name = "Latvia", Tax = 21 },
                new Country() { Name = "Lithuania", Tax = 21 },
                new Country() { Name = "Luxembourg", Tax = 17 },
                new Country() { Name = "Malta", Tax = 18 },
                new Country() { Name = "Netherlands", Tax = 21 },
                new Country() { Name = "Poland", Tax = 23 },
                new Country() { Name = "Portugal", Tax = 23 },
                new Country() { Name = "Romania", Tax = 19 },
                new Country() { Name = "Slovakia", Tax = 20 },
                new Country() { Name = "Slovenia", Tax = 22 },
                new Country() { Name = "Spain", Tax = 21 },
                new Country() { Name = "Sweden", Tax = 25 },
                new Country() { Name = "United Kingdom", Tax = 20 });
        }
    }
}
