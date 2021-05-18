using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryService.Context;
using InventoryService.Specifications;
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

        public async Task DeleteOrderAsync(int Id)
        {
            var order = await _inventoryServiceDbContext.Set<T>().FindAsync(Id);
             _inventoryServiceDbContext.Set<T>().Remove(order);
            await _inventoryServiceDbContext.SaveChangesAsync();
        }

        public async Task<T> GetOrderById(int Id)
        {
           return await _inventoryServiceDbContext.Set<T>().FindAsync(Id);
        }
        
        public async Task<List<T>> GetListAsync()
        {
            return await _inventoryServiceDbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateOrderAsync(T Entity)
        {
            _inventoryServiceDbContext.Set<T>().Update(Entity);
            await _inventoryServiceDbContext.SaveChangesAsync();
        }

        public IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null)
        {
            throw new NotImplementedException();
        }
    }
}
