using System;
using System.Threading.Tasks;
using InventoryService.Context;
using InventoryService.Entity;
using InventoryService.Repositories;
using MassTransit;
using MassTransit.Riders;
using Model;

namespace InventoryService.Comsumers
{
    public class AddOrderConsumer : IConsumer<AddOrder>
    {
        private readonly IBaseRepository<Order> _baseRepository;

        public AddOrderConsumer(IBaseRepository<Order> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task Consume(ConsumeContext<AddOrder> context)
        {
            var order = new Order();
            order.Name = context.Message.Name;
            order.ShipmentDate = context.Message.ShipmentDate;
            await _baseRepository.AddAsync(order);
            //await _inventoryServiceDbContext.Orders.AddAsync(order);
            //await _inventoryServiceDbContext.SaveChangesAsync();
        }
    }
}
