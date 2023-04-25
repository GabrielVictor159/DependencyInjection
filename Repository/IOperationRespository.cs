public interface IOperationRepository
{
    Operation Save(OperationDto dto);
    IList<Operation> SaveIn(IList<Operation> operations);
    Operation Update(Operation operation);
    void Delete(Operation operation);
    void DeleteIn(IList<Operation> operations);
}