using System;
using InventoryService.Entity;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Context
{
    public class InventoryServiceDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        
        public InventoryServiceDbContext(DbContextOptions<InventoryServiceDbContext> options) : base(options)
        {
                
        }
    }
}
