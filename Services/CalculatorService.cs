using DependencyInjection.Model;
namespace DependencyInjection.Services;
public class CalculatorService : ICalculatorService
{
    private readonly ICalculator _calculator;

    public CalculatorService(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public int Options()
    {
        Console.WriteLine("========== Calculator ==========");
        Console.WriteLine("1 -  Add");
        Console.WriteLine("2 - Subtrac");
        Console.WriteLine("3 - Multiply");
        Console.WriteLine("4 - Divide");
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

            switch (option)
            {
                case 1:
                    {
                        IList<decimal> numbers = AskNumbers();
                        Console.WriteLine("Result: " + _calculator.Add(numbers[0], numbers[1]));
                        break;
                    }
                case 2:
                    {
                        IList<decimal> numbers = AskNumbers();
                        Console.WriteLine("Result: " + _calculator.Subtract(numbers[0], numbers[1]));
                        break;
                    }
                case 3:
                    {
                        IList<decimal> numbers = AskNumbers();
                        Console.WriteLine("Result: " + _calculator.Multiply(numbers[0], numbers[1]));
                        break;
                    }
                case 4:
                    {
                        IList<decimal> numbers = AskNumbers(true);
                        Console.WriteLine("Result: " + _calculator.Divide(numbers[0], numbers[1]));
                        break;
                    }
                case 0:
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Option invalid. Type again.");
                    break;
            }
        }
    }

    public IList<decimal> AskNumbers(Boolean? divide = false)
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
            if (divide == true)
            {
                if (number2 == 0)
                {
                    Console.WriteLine("Invalid numbers.");
                    valid = false;
                }

            }
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
