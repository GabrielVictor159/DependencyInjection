
using System;
using DependencyInjection.Model;
using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;


namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ICalculator, Calculator>()
                .AddSingleton<ICalculatorService, CalculatorService>()
                .BuildServiceProvider();
            var menu = serviceProvider.GetService<ICalculatorService>();
            menu.Navigate();
            Console.ReadKey();
        }
    }
}
