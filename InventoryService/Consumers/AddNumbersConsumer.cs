using System;
using System.Threading.Tasks;
using MassTransit;
using Model;

namespace InventoryService.Comsumers
{
    public class AddNumbersConsumer : IConsumer<AddNumbers>
    {
        public Task Consume(ConsumeContext<AddNumbers> context)
        {
            var sum = context.Message.FirstNum + context.Message.SecondNum;
            Console.WriteLine(sum);
            return Task.CompletedTask;
        }
    }
}
