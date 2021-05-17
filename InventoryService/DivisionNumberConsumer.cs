using System;
using System.Threading.Tasks;
using MassTransit;
using Model;

namespace InventoryService
{
    public class DivisionNumberConsumer : IConsumer<DivideNumber>
    {
        public Task Consume(ConsumeContext<DivideNumber> context)
        {
            var Result = context.Message.FirstNum - context.Message.SecondNum;
            Console.WriteLine(Result);
            return Task.CompletedTask;
        }
    }
}
