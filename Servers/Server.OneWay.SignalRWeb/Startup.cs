using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Server.OneWay.SignalRWeb.Contracts;
using Server.OneWay.SignalRWeb.Hubs;
using Server.OneWay.SignalRWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.OneWay.SignalRWeb
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
            services.AddControllers();
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader().
                       AllowCredentials()));
            services.AddSingleton<ICalculator, CalculatorService>();
            services.AddSignalR();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "One way server swagger example API",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                    }
                });
            });

    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example API V1"); //URL: https://localhost:44304/swagger
               // c.RoutePrefix = string.Empty; //URL: https://localhost:44304
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("One way server example");
                });
                endpoints.MapControllers();
                endpoints.MapHub<DateTimeHub>("/dateTimeHub");
            });
        }
    }
}
