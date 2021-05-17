using System;
using System.Threading.Tasks;
using MassTransit;
using Model;

namespace InventoryService
{
    public class MultiplicationConsumer : IConsumer<MultiplyNumber>
    {
        public Task Consume(ConsumeContext<MultiplyNumber> context)
        {
            var Result = context.Message.FirstNum * context.Message.SecondNum;
            Console.WriteLine(Result);
            return Task.CompletedTask;
        }
    }
}
