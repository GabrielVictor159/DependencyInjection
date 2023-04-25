
using System;
using DependencyInjection.Model;
using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices(services =>
         services.AddHostedService<MenuService>()
          .AddDbContext<ApplicationDbContext>()
        .AddScoped<IResultadoRepository, ResultadoRepository>()
        .AddScoped<IOperationRepository, OperationRepository>()
        .AddScoped<ICalculator, Calculator>()
        .AddScoped<IMenu, Menu>()
        .AddScoped<IMenuService, MenuService>()
         );

            using var app = builder.Build();

            app.Run();

        }
    }
}

