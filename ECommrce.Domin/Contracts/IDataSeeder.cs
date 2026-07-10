using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Contracts
{
    public interface IDataSeeder
    {
        Task SeedDataAsync(CancellationToken ct = default);
    }
}
