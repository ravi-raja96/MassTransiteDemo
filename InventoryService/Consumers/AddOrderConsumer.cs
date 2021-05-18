using System;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public AddOrderConsumer(IBaseRepository<Order> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<AddOrder> context)
        {
           // var order = new Order();

            var orders = _mapper.Map<Order>(context.Message);
            //order.Name = context.Message.Name;
            //order.ShipmentDate = context.Message.ShipmentDate;

            await _baseRepository.AddAsync(orders);
        }
    }
}
