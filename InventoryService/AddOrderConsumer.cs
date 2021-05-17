using System;
using System.Threading.Tasks;
using InventoryService.Context;
using InventoryService.Entite;
using MassTransit;
using MassTransit.Riders;
using Model;

namespace InventoryService
{
    public class AddOrderConsumer : IConsumer<AddOrder>
    {
        private readonly InventoryServiceDbContext _inventoryServiceDbContext;

        public AddOrderConsumer(InventoryServiceDbContext inventoryServiceDbContext)
        {
            _inventoryServiceDbContext = inventoryServiceDbContext;
        }

        public async Task Consume(ConsumeContext<AddOrder> context)
        {
           // await Console.Out.WriteLineAsync(context.Message.Name);
            var order = new Order();
            order.Name = context.Message.Name;
            await _inventoryServiceDbContext.Orders.AddAsync(order);
            await _inventoryServiceDbContext.SaveChangesAsync();
        }
    }
}
