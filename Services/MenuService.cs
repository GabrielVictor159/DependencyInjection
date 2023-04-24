using DependencyInjection.Model;
namespace DependencyInjection.Services;
public class MenuService : IMenuService
{
    private readonly IMenu _menu;
    private readonly ApplicationDbContext _context;
    public MenuService(IMenu menu, ApplicationDbContext context)
    {
        _menu = menu;
        _context = context;
    }

    public int Options()
    {
        Console.WriteLine("========== Calculator ==========");
        int index = 1;
        foreach (Options o in _menu.options)
        {
            Console.WriteLine($"{index} - {o.Content}");
            index++;
        }
        Console.WriteLine("0 - Exit");
        Console.Write("Type a menu option: ");
        int option = Convert.ToInt32(Console.ReadLine());
        return option;
    }

    public void Navigate()
    {
        bool exit = false;

        while (!exit)
        {
            int option = Options();

            if (option > _menu.options.Count + 1 || option < 0 || option == null)
            {
                Console.WriteLine("Invalid Select option");
            }
            else if (option == 0)
            {
                Console.WriteLine("Exiting...");
                exit = true;
            }
            else
            {
                try
                {
                    IList<decimal> numbers = AskNumbers();
                    decimal result = (decimal)_menu.options[option - 1].MethodCalculation.DynamicInvoke(numbers[0], numbers[1]);
                    Resultado ResultEntity = new Resultado();
                    ResultEntity.Method = _menu.options[option - 1].MethodString;
                    ResultEntity.Value1 = numbers[0];
                    ResultEntity.Value2 = numbers[1];
                    ResultEntity.Result = result;
                    _context.Results.Add(ResultEntity);
                    _context.SaveChanges();
                    Console.WriteLine("Result: " + result);
                    Console.WriteLine(_context.Results.First());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    public IList<decimal> AskNumbers()
    {
        Boolean exit = false;
        IList<decimal> numbers = new List<decimal>();

        while (!exit)
        {
            Console.WriteLine("Type first number");
            decimal number1 = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Type the second number (this must be greater then 0)");
            decimal number2 = Convert.ToDecimal(Console.ReadLine());
            Boolean valid = true;

            if (number1 == null || number2 == null)
            {
                Console.WriteLine("Invalid numbers.");
                valid = false;
            }
            if (valid == true)
            {
                numbers.Add(number1);
                numbers.Add(number2);
                exit = true;
            }
        }
        return numbers;
    }
}
