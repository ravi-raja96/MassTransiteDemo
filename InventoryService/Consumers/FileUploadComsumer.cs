using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MassTransit;
using Model;

namespace InventoryService.Comsumers
{
    public class FileUploadComsumer : IConsumer<FileUpload>
    {
        public async Task Consume(ConsumeContext<FileUpload> context)
        {
            var FilePath = "/Users/ravirajaparuchuri/Desktop/"+context.Message.FileName;
            await File.WriteAllBytesAsync(FilePath, context.Message.FileByte);
            //var Result =context.Message;
            //Console.WriteLine(Result);
            //return Task.CompletedTask;
        }
    }
}
