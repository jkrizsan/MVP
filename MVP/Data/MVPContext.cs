using Microsoft.EntityFrameworkCore;
using MVP.Data.Models;

namespace MVP.Data
{
    public class MVPContext : DbContext
    {
        public MVPContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
              .HasData(
                new Product() { Id = 1, Name = "Apple", Price = 100 },
                new Product() { Id = 2, Name = "Banana", Price = 199 },
                new Product() { Id = 3, Name = "Car", Price = 9990.5 },
                new Product() { Id = 4, Name = "Pizza", Price = 30 },
                new Product() { Id = 5, Name = "Eggs", Price = 24 });

            modelBuilder.Entity<Country>()
              .HasData(
            new Country() { Id = 1, Name = "Austria", Tax = 20 },
            new Country() { Id = 2, Name = "Belgium", Tax = 21 },
            new Country() { Id = 3, Name = "Bulgaria", Tax = 20 },
            new Country() { Id = 4, Name = "Cyprus", Tax = 19 },
            new Country() { Id = 5, Name = "Czech Republic", Tax = 21 },
            new Country() { Id = 6, Name = "Croatia", Tax = 25 },
            new Country() { Id = 7, Name = "Denmark", Tax = 25 },
            new Country() { Id = 8, Name = "Estonia", Tax = 20 },
            new Country() { Id = 9, Name = "Finland", Tax = 24 },
            new Country() { Id = 10, Name = "France", Tax = 20 },
            new Country() { Id = 11, Name = "Germany", Tax = 19 },
            new Country() { Id = 12, Name = "Greece", Tax = 24 },
            new Country() { Id = 13, Name = "Hungary", Tax = 27 },
            new Country() { Id = 14, Name = "Ireland", Tax = 23 },
            new Country() { Id = 15, Name = "Italy", Tax = 22 },
            new Country() { Id = 16, Name = "Latvia", Tax = 21 },
            new Country() { Id = 17, Name = "Lithuania", Tax = 21 },
            new Country() { Id = 18, Name = "Luxembourg", Tax = 17 },
            new Country() { Id = 19, Name = "Malta", Tax = 18 },
            new Country() { Id = 20, Name = "Netherlands", Tax = 21 },
            new Country() { Id = 21, Name = "Poland", Tax = 23 },
            new Country() { Id = 22, Name = "Portugal", Tax = 23 },
            new Country() { Id = 23, Name = "Romania", Tax = 19 },
            new Country() { Id = 24, Name = "Slovakia", Tax = 20 },
            new Country() { Id = 25, Name = "Slovenia", Tax = 22 },
            new Country() { Id = 26, Name = "Spain", Tax = 21 },
            new Country() { Id = 27, Name = "Sweden", Tax = 25 },
            new Country() { Id = 28, Name = "United Kingdom", Tax = 20 });
        }
    }
}
