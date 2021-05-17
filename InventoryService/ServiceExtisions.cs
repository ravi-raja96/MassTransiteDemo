using System;
using InventoryService.Comsumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryService
{
    public static class ServiceExtisions
    {
        public static void AddMassTransite(this IServiceCollection services)
        {
            services.AddMassTransit(config => {
                config.AddConsumer<AddOrderConsumer>();
                config.AddConsumer<UpdateOrderConsumer>();
                config.AddConsumer<DeleteOrderConsumer>();
                config.AddConsumer<AddNumbersConsumer>();
                config.AddConsumer<DeleteNumberConsumer>();
                config.AddConsumer<DivisionNumberConsumer>();
                config.AddConsumer<MultiplicationConsumer>();
                config.AddConsumer<FileUploadComsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@localhost:5672");

                    cfg.ReceiveEndpoint("Order-Queue", c =>
                    {
                        c.ConfigureConsumer<AddOrderConsumer>(ctx);
                        c.ConfigureConsumer<DeleteOrderConsumer>(ctx);
                        c.ConfigureConsumer<UpdateOrderConsumer>(ctx);
                        c.ConfigureConsumer<AddNumbersConsumer>(ctx);
                        c.ConfigureConsumer<DeleteNumberConsumer>(ctx);
                        c.ConfigureConsumer<DivisionNumberConsumer>(ctx);
                        c.ConfigureConsumer<MultiplicationConsumer>(ctx);
                        c.ConfigureConsumer<FileUploadComsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
