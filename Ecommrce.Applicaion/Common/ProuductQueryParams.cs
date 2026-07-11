using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common
{
    public class ProuductQueryParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; } = default!;
        public string? Search { get; set; } = default!;
        public ProudectSortOptions? Sort { get; set; } = default!;
        public int ? PageIndex { get; set; }
        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;
        private int PageSize;
        public int pageSize {
            get => PageSize;
            set => PageSize = value >MaxPageSize? MaxPageSize: (value <1? DefaultPageSize: value);
        }
    }
}