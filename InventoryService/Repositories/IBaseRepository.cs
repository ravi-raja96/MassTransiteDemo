using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task AddAsync(T Entity);
    }
}
