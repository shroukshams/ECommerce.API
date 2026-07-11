using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Entities
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public ICollection<BasketItems> Items { get; set; } = [];
    }
}
