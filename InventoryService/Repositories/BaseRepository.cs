using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryService.Context;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly InventoryServiceDbContext _inventoryServiceDbContext;

        public BaseRepository(InventoryServiceDbContext inventoryServiceDbContext)
        {
            _inventoryServiceDbContext = inventoryServiceDbContext;
        }

        public async Task AddAsync(T Entity)
        {
              _inventoryServiceDbContext.Set<T>().Add(Entity);
             await _inventoryServiceDbContext.SaveChangesAsync();

        }

        public async Task<List<T>> GetListAsync()
        {
            return await _inventoryServiceDbContext.Set<T>().ToListAsync();
        }

        
    }
}
