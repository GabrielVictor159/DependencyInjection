
using System;
using DependencyInjection.Model;
using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    try
                    {
                        options.UseNpgsql("Server=db; Port=5432; Database=postgres; Uid=postgres; Pwd=postgres;");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error configuring DbContext: {ex.Message}");
                        throw;
                    }
                })
                .AddScoped<ICalculator, Calculator>()
                .AddSingleton<IMenu, Menu>()
                .AddSingleton<IMenuService, MenuService>()
                .BuildServiceProvider();
            var menu = serviceProvider.GetService<IMenuService>();
            menu.Navigate();

        }
    }
}

