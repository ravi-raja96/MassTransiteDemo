using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using OrderService.Context;
using OrderService.Dto.Request;
using OrderService.Entity;
using OrderService.Repositories;
using OrderService.Repositories.Specification;

namespace OrderService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IPublishEndpoint _publishEndpoint;
		private readonly IBaseRepository<Order> _orderRepository;
		public OrderController(IPublishEndpoint publishEndpoint, IBaseRepository<Order> orderRepository)
		{
			_publishEndpoint = publishEndpoint;
			_orderRepository = orderRepository;
		}

		// GET: api/Order
		[HttpGet]
		public IActionResult Get()
		{
			var upcomingShipmentsSpecification = new UpcomingOrderShipmentSpecification();

			var orders = _orderRepository.FindWithSpecificationPattern(upcomingShipmentsSpecification);

			return Ok(orders);
		}

		// GET: api/Order/5
		[HttpGet("{id}", Name = "Get")]
		public async Task<IActionResult> Get(int id)
		{
			var order = await _orderRepository.GetById(id);
			return Ok(order);
		}

		// POST: api/Order
		[HttpPost]
		public async Task<IActionResult> Post(OrderRequest orderRequest)
		{
			var Order = new Order
			{
				Name = orderRequest.Name,
				ShipmentDate = orderRequest.ShipmentDate
			};

			await _orderRepository.AddAsync(Order);

            //await _publishEndpoint.Publish<Model.Order>(order);
            var NewOrder = new AddOrder();
            NewOrder.Name = orderRequest.Name;
			NewOrder.ShipmentDate = orderRequest.ShipmentDate;
            await _publishEndpoint.Publish(NewOrder);
            return Ok();
		}

		// PUT: api/Order/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, OrderRequest orderRequest)
		{
			var order = await _orderRepository.GetById(id);
			if (order == null)
			{
				return NotFound($"Order doesn't exist for Id: {id}");
			}

			order.Name = orderRequest.Name;
			order.ShipmentDate = orderRequest.ShipmentDate;
			await _orderRepository.UpdateAsync(order);

            var updateOrder = new UpdateOrder();
            updateOrder.Name = orderRequest.Name;
            updateOrder.Id = id;

            await _publishEndpoint.Publish(updateOrder);
            return Ok();

		}

		// DELETE: api/Order/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _orderRepository.DeleteAsync(id);
			//var DeleteOrder = new DeleteOrder();
			//DeleteOrder.Id = Data.Id;
			//await _publishEndpoint.Publish(DeleteOrder);
			return Ok();
		}
	}
}
