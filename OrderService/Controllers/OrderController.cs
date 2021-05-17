using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using OrderService.Context;
using OrderService.Entity;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderServiceDbContext _orderServiceDbContext;
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderController(IPublishEndpoint publishEndpoint, OrderServiceDbContext orderServiceDbContext)
        {
            _publishEndpoint = publishEndpoint;
            _orderServiceDbContext = orderServiceDbContext;
        }
        // GET: api/Order
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> Post(string order)
        {
            var Order = new Order();
            Order.Name = order;
            await _orderServiceDbContext.Orders.AddAsync(Order);
            //await _publishEndpoint.Publish<Model.Order>(order);
            await _orderServiceDbContext.SaveChangesAsync();
            var NewOrder = new AddOrder();
            NewOrder.Name = order;
            await _publishEndpoint.Publish(NewOrder);
            return Ok();
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, string value)
        {
            var Data = _orderServiceDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (Data == null)
            {
                return Ok("Data does't exisits");
            }
           Data.Name = value;
             _orderServiceDbContext.Orders.Update(Data);
            await _orderServiceDbContext.SaveChangesAsync();
            var updateOrder = new UpdateOrder();
            updateOrder.Name = value;
            updateOrder.Id = id;
            
            await _publishEndpoint.Publish(updateOrder);
            return Ok(); 

        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Data = _orderServiceDbContext.Orders.FirstOrDefault(x => x.Id == id);
             _orderServiceDbContext.Orders.Remove(Data);
           await _orderServiceDbContext.SaveChangesAsync();
            var DeleteOrder = new DeleteOrder();
            DeleteOrder.Id = Data.Id;
            await _publishEndpoint.Publish(DeleteOrder);
            return Ok();
        }
    }
}
