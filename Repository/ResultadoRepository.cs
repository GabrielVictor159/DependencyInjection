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
        return resultado;
    }

    public IList<Resultado> SaveIn(IList<Resultado> resultados)
    {
        _context.AddRange(resultados);
        _context.SaveChanges();
        return resultados;
    }

    public Resultado Update(Resultado resultado)
    {
        _context.Add(resultado);
        _context.SaveChanges();
        return resultado;
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
    public List<Resultado> GetResultadosPagination(int pagina, int quantidade)
    {
        {
            var resultados = _context.Results
                .OrderByDescending(r => r.Id)
                .Skip((pagina - 1) * quantidade)
                .Take(quantidade)
                .ToList();

            return resultados;
        }
    }

}