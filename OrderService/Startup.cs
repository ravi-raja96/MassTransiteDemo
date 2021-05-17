using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Riders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Model;
using OrderService.Config;
using OrderService.Context;
using OrderService.Repositories;

namespace OrderService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransite();

            var postgresConfig = Configuration
                .GetSection("PostgresConfig").Get<PostgresConfig>();
            var connectString = postgresConfig.ConnectionString;
            services.AddDbContext<OrderServiceDbContext>(x => x.UseNpgsql(connectString));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            //{
            //    config.Host("amqp://guest:guest@localhost:5672");

            //    config.ReceiveEndpoint("temp-queue", c =>
            //    {
            //        c.Handler<Order>(ctx =>
            //        {
            //            return Console.Out.WriteLineAsync(ctx.Message.Name);
            //        });
            //    });

            //});

            //bus.Start();

            //bus.Publish(new Order { Name="Testing MassTransite"});
        }
    }
}
