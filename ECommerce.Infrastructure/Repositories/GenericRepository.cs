using ECommerce.Domin.Contracts;
using ECommerce.Domin.Entities;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Repositories
{
    public class GenericRepository<TEinty, TKey>(StoreDbContext dbContext) : IGenericRepository<TEinty, TKey> where TEinty : BaseEntity<TKey>
    {


        public void Add(TEinty entity)
        =>dbContext.Set<TEinty>().Add(entity);

        public async Task<int> CountAsync(ISpecification<TEinty, TKey> spec, CancellationToken ct = default)
        {

            return await specificationEvaluator.CreateQuery(dbContext.Set<TEinty>(), spec).CountAsync(ct);
        }

        public void Delete(TEinty entity)
        =>dbContext.Set<TEinty>().Remove(entity);   

        public async Task<IReadOnlyList<TEinty>> GetAllAsync(CancellationToken ct = default)
=> await dbContext.Set<TEinty>().ToListAsync<TEinty>(ct);

        public async Task<IReadOnlyList<TEinty>> GetAllAsync(ISpecification<TEinty, TKey> Spec, CancellationToken ct = default)
        {
            var query = specificationEvaluator.CreateQuery(dbContext.Set<TEinty>(), Spec);
         
        return await query.ToListAsync(); }

        public async Task<TEinty> GetByIDAsync(TKey id, CancellationToken ct = default)
        =>await dbContext.Set<TEinty>().FindAsync(id, ct);

        public Task<TEinty> GetByIDAsync(ISpecification<TEinty, TKey> spec, CancellationToken ct = default)
        {
            var query = specificationEvaluator.CreateQuery(dbContext.Set<TEinty>(), spec);
            return query.FirstOrDefaultAsync(ct);
        }

        public void Update(TEinty entity)
        => dbContext.Set<TEinty>().Update(entity);
    }
}
