using System;
using Microsoft.EntityFrameworkCore;
using OrderService.Entity;

namespace OrderService.Context
{
    public class OrderServiceDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options) : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
