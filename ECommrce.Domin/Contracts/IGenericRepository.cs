using ECommerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domin.Contracts
{
    public interface IGenericRepository<TEinty,TKey> where TEinty:BaseEntity<TKey>
    {
        void Add(TEinty entity);
        void Update(TEinty entity);
        void Delete(TEinty entity);
        Task<TEinty> GetByIDAsync(TKey id,CancellationToken ct=default);
        Task<TEinty> GetByIDAsync(ISpecification<TEinty, TKey> spec, CancellationToken ct = default);

        Task<IReadOnlyList<TEinty>> GetAllAsync(CancellationToken ct=default);
        Task<IReadOnlyList<TEinty>> GetAllAsync(ISpecification<TEinty, TKey> spec, CancellationToken ct = default);
        Task <int> CountAsync(ISpecification<TEinty, TKey> spec, CancellationToken ct = default);
    }
}
