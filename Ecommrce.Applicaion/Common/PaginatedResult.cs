using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common
{
    public class PaginatedResult<TEntity>
    {
        public int pageIndex { get; }
        public int pageSize { get; }
        public int Count { get; } = 0;
        public IReadOnlyList<TEntity>Data { get; }


        public PaginatedResult(int pageIndex, int pageSize, int count, IReadOnlyList<TEntity> data)
        {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
            Count = count;
            Data = data;
        }
    }
}
