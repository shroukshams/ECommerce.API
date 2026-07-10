using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Application.Specification
{
    public class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public ICollection<Expression<Func<TEntity, object>>> IncludesExpressions { get; } = [];

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        protected   void AddInclude(Expression<Func<TEntity, object>> include)
        {
            IncludesExpressions.Add(include);
        }
      
        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}
