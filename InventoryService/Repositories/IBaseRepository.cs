using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryService.Specifications;

namespace InventoryService.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task AddAsync(T Entity);
        Task DeleteOrderAsync(int Id);
        Task UpdateOrderAsync(T Entity);
        Task<T> GetOrderById(int Id);
        IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);

    }
}
