using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerce.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository

    {
        private readonly IDatabase  database;
        public BasketRepository(IConnectionMultiplexer connection) {
            database = connection.GetDatabase();

        }
        public async Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TimeTolive = null, CancellationToken ct = default)
        {
            var value = JsonSerializer.Serialize(basket);
            var reslut= await database.StringSetAsync(basket.Id, value, TimeTolive??TimeSpan.FromDays(7));
            return reslut ? basket : null;
        }

        public Task<bool> DeleteBasketAsync(string basketId, CancellationToken ct = default)
        {
            return database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId, CancellationToken ct = default)
        {
            var basket =await database.StringGetAsync(basketId);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>((string?)basket!);
        }
    }
}
