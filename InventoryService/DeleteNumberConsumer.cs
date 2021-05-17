using System;
using System.Threading.Tasks;
using MassTransit;
using Model;

namespace InventoryService
{
    public class DeleteNumberConsumer : IConsumer<DeleteNumber>
    {
        public Task Consume(ConsumeContext<DeleteNumber> context)
        {
            var Result = context.Message.FirstNum - context.Message.SecondNum;
            Console.WriteLine(Result);
            return Task.CompletedTask;
        }

    }
}
