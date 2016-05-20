public class UndoLastOperation : IOperation, IOperationFactory
{
    public int OperationType => 4;

    public void Execute(object parameter)
    {
        
    }

    public IOperation MakeOperation(string commandInfo)
    {
        return new UndoLastOperation();
    }
}