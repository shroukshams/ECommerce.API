using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common
{
    public class ProuductQueryParams
    {
        public int? BrandId { get; set; }
        public string TypeId { get; set; } = default!;
        public string Search { get; set; } = default!;
        public ProudectSortOptions Sort { get; set; } = default!;
    }
}