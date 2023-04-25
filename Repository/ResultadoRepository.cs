public class ResultadoRepository : IResultadoRepository
{
    private readonly ApplicationDbContext _context;

    public ResultadoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Resultado Save(ResultadoDto dto)
    {
        Resultado resultado = new Resultado();
        resultado.OperationId = dto.operation.Id;
        resultado.operation = dto.operation;
        resultado.Result = dto.Result;
        _context.Add(resultado);
        _context.SaveChanges();
        Resultado operationResult = _context.Results.Where(b => b.Id == resultado.Id).First();
        return operationResult;
    }

    public IList<Resultado> SaveIn(IList<Resultado> resultados)
    {
        _context.AddRange(resultados);
        _context.SaveChanges();
        IList<Guid> ids = resultados.Select(p => p.Id).ToList();
        IList<Resultado> resultadosResult = _context.Results.Where(b => ids.Contains(b.Id)).ToList();
        return resultadosResult;
    }

    public Resultado Update(Resultado resultado)
    {
        _context.Add(resultado);
        _context.SaveChanges();
        Resultado resultadosResult = _context.Results.Where(b => b.Id == resultado.Id).First();
        return resultadosResult;
    }

    public void Delete(Resultado resultado)
    {
        _context.Results.Remove(resultado);
        _context.SaveChanges();
    }

    public void DeleteIn(IList<Resultado> results)
    {
        _context.Results.RemoveRange(results);
        _context.SaveChanges();
    }
}