public interface IOperationFactory
{
    int OperationType { get; }

    IOperation MakeOperation(string operationInfo);
}