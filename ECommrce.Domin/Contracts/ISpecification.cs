using ECommerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Domin.Contracts
{
    public interface ISpecification<TEntity, TKey>where TEntity : BaseEntity<TKey>
    {
        //Includes related entities
        ICollection<Expression<Func<TEntity, object>>> IncludesExpressions { get; }
        Expression<Func<TEntity,bool>>Criteria { get; }
        Expression<Func<TEntity, object>> OrderBY { get; }
        Expression<Func<TEntity, object>> OrderBYDescending { get; }



    }
}
