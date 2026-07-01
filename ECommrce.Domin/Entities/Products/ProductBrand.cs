using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Entities.Products
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; } = default!;

    }
}
