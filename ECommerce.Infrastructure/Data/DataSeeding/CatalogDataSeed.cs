using ECommerce.Domin.Cintracts;
using ECommerce.Domin.Entities;
using ECommerce.Domin.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ECommerce.Infrastructure.Data.DataSeeding
{
    public class CatalogDataSeed(StoreDbContext dbContext, ILogger logger) : IDataSeeder
    {

        public async Task SeedDataAsync(CancellationToken ct = default)
        {
            try
            {
                var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    await dbContext.Database.MigrateAsync();
                }
                var rootPath = Path.Combine(AppContext.BaseDirectory, "DataSeeding", "SeedData");
                await SeedDataIfEmptyAsync<ProductBrand, int>(rootPath, "brands.json", ct);
                await SeedDataIfEmptyAsync<ProductType, int>(rootPath, "types.json", ct);
                await SeedDataIfEmptyAsync<Product, int>(rootPath, "products.json", ct);
                var result = await dbContext.SaveChangesAsync(ct);
                if (result > 0)
                {
                    logger.LogInformation("Data seeded successfully.");
                }
                else
                {
                    logger.LogWarning("No data was seeded.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding data.");
            }
        }
        //method to read From json file and seed data to database

        private async Task SeedDataIfEmptyAsync<T, TKey>(string rootPath, string fileName, CancellationToken ct = default) where T : BaseEntity<TKey>
        {
            {
                if (dbContext.Set<T>().Any())
                {

                    return;
                }
                var filePath = Path.Combine(rootPath, fileName);
                if (!File.Exists(filePath))
                {
                    return;
                }
                var filestream = File.OpenRead(filePath);
                var items = await JsonSerializer.DeserializeAsync<List<T>>(filestream);
                if (items?.Any() ?? false)
                {
                     dbContext.Set<T>().AddRange(items);
                }
            }
        }
    }
}
