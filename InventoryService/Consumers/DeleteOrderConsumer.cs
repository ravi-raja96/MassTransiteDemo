using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Context;
using MassTransit;
using Model;

namespace InventoryService.Comsumers
{
    public class DeleteOrderConsumer : IConsumer<DeleteOrder>
    {
        private readonly InventoryServiceDbContext _inventoryServiceDbContext;

        public DeleteOrderConsumer(InventoryServiceDbContext inventoryServiceDbContext)
        {
            _inventoryServiceDbContext = inventoryServiceDbContext;
        }

        public async Task Consume(ConsumeContext<DeleteOrder> context)
        {
            var Data = _inventoryServiceDbContext.Orders.FirstOrDefault(x => x.Id == context.Message.Id);
            _inventoryServiceDbContext.Orders.Remove(Data);
            await _inventoryServiceDbContext.SaveChangesAsync();
        }
    }
}
