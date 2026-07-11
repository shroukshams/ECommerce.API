using ECommerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId, CancellationToken ct = default);
        Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket basket,TimeSpan?TimeTolive=default, CancellationToken ct = default);
        Task<bool> DeleteBasketAsync(string basketId, CancellationToken ct = default);
    }
}
