using DependencyInjection.Model;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace DependencyInjection.Services;
public class MenuService : BackgroundService, IMenuService
{
    private readonly IMenu _menu;
    private readonly IOperationRepository _operationRepostiroy;
    private readonly IResultadoRepository _resultadoRepository;
    private String selectCategoria { get; set; }
    public MenuService(IMenu menu, IOperationRepository operationRepository, IResultadoRepository resultadoRepository)
    {
        _menu = menu;
        _operationRepostiroy = operationRepository;
        _resultadoRepository = resultadoRepository;

    }


    public void OptionsMenus()
    {

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("========== Calculator ==========");
            int index = 1;
            IList<String> categories = new List<String>();
            foreach (string category in _menu.optionsByCategory.Keys)
            {
                Console.WriteLine($"{index} - {category} ---");
                categories.Add(category);
                index++;
            }
            Console.WriteLine("0 - Exit");
            Console.Write("Type a menu option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option > _menu.optionsByCategory.Count + 1 || option < 0 || option == null)
            {
                Console.WriteLine("Invalid Select option");
            }
            else if (option == 0)
            {
                Console.WriteLine("Exiting...");
                selectCategoria = "saida";
                exit = true;
            }
            else
            {
                selectCategoria = categories[option - 1];
                exit = true;
            }

        }
    }
    public int Options(IList<Options> options)
    {
        int option = 0;
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("========== Calculator ==========");
            int index = 1;
            foreach (Options o in options)
            {
                Console.WriteLine($"{index} - {o.Content}");
                index++;
            }
            Console.WriteLine("0 - Exit");
            Console.Write("Type a menu option: ");
            option = Convert.ToInt32(Console.ReadLine());
            if (option > options.Count + 1 || option < 0 || option == null)
            {
                Console.WriteLine("Invalid Select option");
            }
            else if (option == 0)
            {
                exit = true;
            }
            else
            {
                exit = true;
            }
        }
        return option;
    }
    public void Navigate()
    {
        bool exit = false;
        while (!exit)
        {
            OptionsMenus();
            if (selectCategoria == "saida")
            {
                exit = true;
            }
            else
            {
                IList<Options> menuOptions = _menu.optionsByCategory[selectCategoria];
                int a = Options(menuOptions);
                if (a == 0)
                {
                    Console.WriteLine("Exiting...");
                    exit = true;
                }
                else
                {
                    MethodInfo methodInfo = menuOptions[a - 1].MethodCalculation.GetMethodInfo();
                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                    object[] parameterValues;
                    if (parameterInfos.Length > 0)
                    {
                        parameterValues = new object[parameterInfos.Length];
                        for (int i = 0; i < parameterInfos.Length; i++)
                        {
                            ParameterInfo parameterInfo = parameterInfos[i];

                            Console.Write($"Informe o valor para {parameterInfo.Name} ({parameterInfo.ParameterType}): ");
                            string value = Console.ReadLine();

                            object convertedValue = Convert.ChangeType(value, parameterInfo.ParameterType);
                            parameterValues[i] = convertedValue;
                        }

                        if (methodInfo.ReturnType != typeof(void))
                        {
                            try
                            {
                                if (menuOptions[a - 1].Persist == true)
                                {
                                    OperationDto dto = new OperationDto();
                                    String[] arrayDeStrings = Array.ConvertAll(parameterValues, x => x.ToString());
                                    dto.values = "[" + string.Join(",", arrayDeStrings) + "]";
                                    dto.Method = methodInfo.Name;
                                    Operation operation = _operationRepostiroy.Save(dto);

                                    var result = menuOptions[a - 1].MethodCalculation.DynamicInvoke(parameterValues);
                                    ResultadoDto dtoResultado = new ResultadoDto();
                                    dtoResultado.operation = operation;
                                    dtoResultado.Result = result.ToString();
                                    _resultadoRepository.Save(dtoResultado);
                                    Console.WriteLine("Result: " + result);
                                }
                                else
                                {
                                    var result = menuOptions[a - 1].MethodCalculation.DynamicInvoke(parameterValues);
                                    Console.WriteLine("Result: " + result);
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid Action");
                            }
                        }
                        else
                        {
                            try
                            {
                                menuOptions[a - 1].MethodCalculation.DynamicInvoke(parameterValues);
                                Console.WriteLine("Operação realizada");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid Action");
                            }
                        }
                    }
                    else
                    {
                        if (methodInfo.ReturnType != typeof(void))
                        {
                            try
                            {
                                if (menuOptions[a - 1].Persist == true)
                                {
                                    OperationDto dto = new OperationDto();
                                    dto.Method = methodInfo.Name;
                                    Operation operation = _operationRepostiroy.Save(dto);
                                    var result = menuOptions[a - 1].MethodCalculation.DynamicInvoke();
                                    ResultadoDto dtoResultado = new ResultadoDto();
                                    dtoResultado.operation = operation;
                                    dtoResultado.Result = result.ToString();
                                    _resultadoRepository.Save(dtoResultado);
                                    Console.WriteLine("Result: " + result);
                                }
                                else
                                {
                                    var result = menuOptions[a - 1].MethodCalculation.DynamicInvoke();
                                    Console.WriteLine("Result: " + result);
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid Action");
                            }
                        }
                        else
                        {
                            try
                            {
                                menuOptions[a - 1].MethodCalculation.DynamicInvoke();
                                Console.WriteLine("Operação realizada");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid Action");
                            }
                        }
                    }

                }
            }

        }

    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Navigate();
        await Task.Delay(1000, stoppingToken);

    }
}
