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
    public class UpdateOrderConsumer : IConsumer<UpdateOrder>
    {
        private readonly IBaseRepository<Order> _baseRepository;
        private readonly IMapper _mapper;

        public UpdateOrderConsumer(IBaseRepository<Order> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<UpdateOrder> context)
        {

            var orders = await _baseRepository.GetOrderById(context.Message.Id);
            if (orders == null)
            {
                return;
            }
            orders= _mapper.Map<Order>(context.Message);
            //orders.Name = context.Message.Name;
            //orders.ShipmentDate = context.Message.ShipmentDate;
            await _baseRepository.UpdateOrderAsync(orders);

        }
    }
}
