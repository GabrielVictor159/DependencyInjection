using DependencyInjection.Model;
using System.Reflection;
public class Menu : IMenu

{
	public IList<Options> options {get; private set;}

	public Menu(ICalculator calculator)
	{
		options = new List<Options>();
		options.Add(new Options("Add", calculator.Add));
		options.Add(new Options("Subtract",calculator.Subtract));
		options.Add(new Options("Multiply",calculator.Multiply));
		options.Add(new Options("Divide",calculator.Divide));
	}

}