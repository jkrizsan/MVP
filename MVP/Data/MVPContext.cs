using Microsoft.EntityFrameworkCore;
using MVP.Data.Models;
using System;

namespace MVP.Data
{
    public class MVPContext : DbContext
    {
        public MVPContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
