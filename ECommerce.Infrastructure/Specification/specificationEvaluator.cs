using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Specification
{
    public static class specificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> entryPoint, ISpecification<TEntity, TKey> spec) where TEntity : BaseEntity<TKey>
        {
            var query = entryPoint;
            //2 where
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            //3 includes
            //if(spec != null)
            //{
            //    if (spec.IncludesExpressions.Any())
            //    {
            //        foreach (var expresion in spec.IncludesExpressions)
            //        {
            //            query = query.Include(expresion);
            //        }

            //    }
            //}
            query = spec.IncludesExpressions.Aggregate(query, (current, nextExp) => current.Include(nextExp));
            //4 order by
            if (spec.OrderBY != null)
            {
                query = query.OrderBy(spec.OrderBY);
            }
            else if (spec.OrderBYDescending != null)
            {
                query = query.OrderByDescending(spec.OrderBYDescending);
            }
            if (spec.IsPaginated)
            {
                // تأكد من تحديث متغير query هنا
                query = query.Skip(spec.Skip).Take(spec.TAKE);
            }
            return query;
        }
    }
}
