using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Entities.Products
{
    public class ProductType : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
    }
}
