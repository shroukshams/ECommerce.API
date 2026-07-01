using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Entities.Products
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }=default!;
        public string Description { get; set; }= default!;
        public string PictureUrl { get; set; } = default!;
        public decimal Price { get; set; } 
        public ProductBrand ProductBrand { get; set; } = default!;
        public int ProductBrandId { get; set; }
public ProductType ProductType { get; set; } = default!;
        public int ProductTypeId { get; set; }
    }
}
