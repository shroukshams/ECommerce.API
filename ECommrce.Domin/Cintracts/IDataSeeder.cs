using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Cintracts
{
    public interface IDataSeeder
    {
        Task SeedDataAsync(CancellationToken ct = default);
    }
}
