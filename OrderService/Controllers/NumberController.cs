using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using OrderService.Entity;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NumberController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> AddNumber(Numbers numbers)
        {
            if (numbers.Operator == "+")
            {
                var AddnumberEvent = new AddNumbers();
                AddnumberEvent.FirstNum = numbers.FirstNum;
                AddnumberEvent.SecondNum = numbers.SecondNum;
                await _publishEndpoint.Publish(AddnumberEvent);
                return Ok();
            }
            else if(numbers.Operator=="-")
            {
                var DeletenumberEvent = new DeleteNumber();
                DeletenumberEvent.FirstNum = numbers.FirstNum;
                DeletenumberEvent.SecondNum = numbers.SecondNum;
                await _publishEndpoint.Publish(DeletenumberEvent);
                return Ok();
            }
            else if (numbers.Operator == "/")
            {
                var DividenumberEvent = new DivideNumber();
                DividenumberEvent.FirstNum = numbers.FirstNum;
                DividenumberEvent.SecondNum = numbers.SecondNum;
                await _publishEndpoint.Publish(DividenumberEvent);
                return Ok();
            }
            else
            {
                var MultiplynumberEvent = new MultiplyNumber();
                MultiplynumberEvent.FirstNum = numbers.FirstNum;
                MultiplynumberEvent.SecondNum = numbers.SecondNum;
                await _publishEndpoint.Publish(MultiplynumberEvent);
                return Ok();
            }
            //Iformfile
        }
    }
}