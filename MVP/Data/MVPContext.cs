using Microsoft.EntityFrameworkCore;
using MVP.Data.Models;

namespace MVP.Data
{
    public class MVPContext : DbContext
    {
        public MVPContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData.Initialize(modelBuilder);
        }
    }
}
