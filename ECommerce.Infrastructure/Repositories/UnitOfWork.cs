using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using ECommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Repositories
{
    public class UnitOfWork(StoreDbContext dbContext) : IUnitOfWork

    {
        private readonly Dictionary<string, object> repositories = [];

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await dbContext.SaveChangesAsync(ct);
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName = typeof(TEntity).Name;

            // الشرط الصحيح: إذا لم يكن موجوداً، قم بإنشائه
            if (!repositories.ContainsKey(typeName))
            {
                var repository = new GenericRepository<TEntity, TKey>(dbContext);
                repositories[typeName] = repository;
            }

            // إرجاع الـ Repository الموجود في القاموس
            return (IGenericRepository<TEntity, TKey>)repositories[typeName];
        }



    }
}

