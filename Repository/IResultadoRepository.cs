public interface IResultadoRepository
{
    Resultado Save(ResultadoDto dto);
    IList<Resultado> SaveIn(IList<Resultado> resultados);
    Resultado Update(Resultado resultado);
    void Delete(Resultado resultado);
    void DeleteIn(IList<Resultado> results);
}