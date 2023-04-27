public class OperationRepository : IOperationRepository
{
    private readonly ApplicationDbContext _context;

    public OperationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Operation Save(OperationDto dto)
    {
        Operation operation = new Operation();
        operation.Method = dto.Method;
        operation.Values = dto.values;
        _context.Add(operation);
        _context.SaveChanges();
        return operation;
    }

    public IList<Operation> SaveIn(IList<Operation> operations)
    {
        _context.AddRange(operations);
        _context.SaveChanges();
        return operations;
    }

    public Operation Update(Operation operation)
    {
        _context.Add(operation);
        _context.SaveChanges();
        return operation;
    }

    public void Delete(Operation operation)
    {
        _context.Operations.Remove(operation);
        _context.SaveChanges();
    }

    public void DeleteIn(IList<Operation> operations)
    {
        _context.Operations.RemoveRange(operations);
        _context.SaveChanges();
    }

    public List<Operation> GetOperationsPagination(int pagina, int quantidade)
    {
        {
            var operations = _context.Operations
                .OrderByDescending(r => r.Id)
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToList();

            return operations;
        }
    }


}