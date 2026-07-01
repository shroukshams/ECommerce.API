using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; } = default!;

    }
}
