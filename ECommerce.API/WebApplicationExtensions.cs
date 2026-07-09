using ECommerce.Domin.Cintracts;

namespace ECommerce.API
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> MigrateDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");
            await seeder.SeedDataAsync();
            await seeder.SeedDataAsync();
            return app;
        }
    }
}

