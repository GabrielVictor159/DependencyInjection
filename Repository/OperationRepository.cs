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
        Operation operationResult = _context.Operations.Where(b => b.Id == operation.Id).First();
        return operationResult;
    }

    public IList<Operation> SaveIn(IList<Operation> operations)
    {
        _context.AddRange(operations);
        _context.SaveChanges();
        IList<Guid> ids = operations.Select(p => p.Id).ToList();
        IList<Operation> operationsResult = _context.Operations.Where(b => ids.Contains(b.Id)).ToList();
        return operationsResult;
    }

    public Operation Update(Operation operation)
    {
        _context.Add(operation);
        _context.SaveChanges();
        Operation operationResult = _context.Operations.Where(b => b.Id == operation.Id).First();
        return operationResult;
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