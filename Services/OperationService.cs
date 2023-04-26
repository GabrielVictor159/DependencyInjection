public class OperationService : IOperationService
{
    private readonly IOperationRepository _IOperationRepository;
    public OperationService(IOperationRepository ioperationRepository)
    {
        _IOperationRepository = ioperationRepository;
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
            IList<Operation> operations = _IOperationRepository.GetOperationsPagination(index, size);
            foreach (Operation operation in operations)
            {
                Console.WriteLine(operation.ToString());
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