using System;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace OrderService
{
    public static class ServiceExitisions
    {
        public static void AddMassTransite(this IServiceCollection services)
        {
            services.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@localhost:5672");
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
