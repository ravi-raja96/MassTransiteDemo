using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventoryService.Context;
using InventoryService.Entity;
using InventoryService.Repositories;
using MassTransit;
using Model;

namespace InventoryService.Comsumers
{
    public class DeleteOrderConsumer : IConsumer<DeleteOrder>
    {
        private readonly IBaseRepository<Order> _baseRepository;
      

        public DeleteOrderConsumer(IBaseRepository<Order> baseRepository)
        {
            _baseRepository = baseRepository;
           
        }

        public async Task Consume(ConsumeContext<DeleteOrder> context)
        {
            await _baseRepository.DeleteOrderAsync(context.Message.Id);
        }
    }
}
