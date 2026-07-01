using ECommerce.Domin.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Data
{
    public class StoreDbContext(DbContextOptions<StoreDbContext> options) :  DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductBrand> ProductBrands { get; set; } = default!;
        public DbSet<ProductType> ProductTypes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }
    }
}
