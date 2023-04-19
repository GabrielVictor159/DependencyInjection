
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
				.AddSingleton<IMenu, Menu>()
				.AddSingleton<IMenuService, MenuService>()
				.BuildServiceProvider();
			var menu = serviceProvider.GetService<IMenuService>();
			menu.Navigate();
			Console.ReadKey();
		}
	}
}
