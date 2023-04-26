public class ResultadoService : IResultadoService
{
    private readonly IResultadoRepository _iResultadoReposytory;
    public ResultadoService(IResultadoRepository _iresultadoRepository)
    {
        _iResultadoReposytory = _iresultadoRepository;
    }

    public void PageItems()
    {
        Boolean exit = false;
        int index = 1;
        int size = 10;
        Boolean exitSizeWhile = false;
        while (!exitSizeWhile)
        {
            Console.WriteLine("How many items will be shown (1 to 100) ?");
            Console.Write("Enter an integer: ");
            size = Convert.ToInt32(Console.ReadLine());
            if (size < 1 || size > 100)
            {
                Console.WriteLine("Invalid number");
            }
            else
            {
                exitSizeWhile = true;
            }
        }
        while (!exit)
        {

            Console.WriteLine("========= Pagination ========");
            IList<Resultado> resultados = _iResultadoReposytory.GetResultadosPagination(index, size);
            foreach (Resultado resultado in resultados)
            {
                Console.WriteLine(resultado.ToString());
            }
            Console.WriteLine("========= Press LEFT or RIGHT =========");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (index > 1)
                {
                    index--;
                }
                else
                {
                    exit = true;
                    Console.WriteLine("Exiting pagination....");
                }
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                index++;
            }

        }
    }

}