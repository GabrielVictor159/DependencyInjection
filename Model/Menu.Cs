using DependencyInjection.Model;
using System.Reflection;
public class Menu : IMenu

{
    public Dictionary<string, IList<Options>> optionsByCategory { get; set; }

    public Menu(ICalculator calculator, IOperationService iOperationService, IResultadoService iResultadoService)
    {
        optionsByCategory = new Dictionary<string, IList<Options>>();
        IList<Options> options = new List<Options>();
        options.Add(new Options("Add", calculator.Add));
        options.Add(new Options("Subtract", calculator.Subtract));
        options.Add(new Options("Multiply", calculator.Multiply));
        options.Add(new Options("Divide", calculator.Divide));
        optionsByCategory.Add("Calculator", options);
        IList<Options> options2 = new List<Options>();
        options2.Add(new Options("Pagination of Operations", iOperationService.PageItems, false));
        options2.Add(new Options("Pagination of Results", iResultadoService.PageItems, false));
        optionsByCategory.Add("database queries", options2);


    }





}