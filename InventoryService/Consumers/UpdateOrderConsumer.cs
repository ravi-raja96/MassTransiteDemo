using System;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Context;
using InventoryService.Entity;
using MassTransit;
using Model;

namespace InventoryService.Comsumers
{
    public class UpdateOrderConsumer : IConsumer<UpdateOrder>
    {
        private readonly InventoryServiceDbContext _inventoryServiceDbContext;

        public UpdateOrderConsumer(InventoryServiceDbContext inventoryServiceDbContext)
        {
            _inventoryServiceDbContext = inventoryServiceDbContext;
        }

        public async Task Consume(ConsumeContext<UpdateOrder> context)
        {
            //var order = new Order();
            //order.Name=
         var Data = _inventoryServiceDbContext.Orders.FirstOrDefault(x => x.Id == context.Message.Id);
            if (Data == null)
            {
                return ;
                //Console.WriteLine("null value");
            }
            Data.Name = context.Message.Name;
             _inventoryServiceDbContext.Orders.Update(Data);
            await _inventoryServiceDbContext.SaveChangesAsync();

        }
    }
}
