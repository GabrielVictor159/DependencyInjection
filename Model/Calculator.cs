namespace DependencyInjection.Model;
public class Calculator : ICalculator
{
    public decimal Add(decimal x, decimal y)
    {
        return x + y;
    }

    public decimal Divide(decimal x, decimal y)
    {
        return x / y;
    }

    public decimal Multiply(decimal x, decimal y)
    {
        return x * y;
    }

    public decimal Subtract(decimal x, decimal y)
    {
        return x - y;
    }
}

