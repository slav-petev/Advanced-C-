using System.Text;

public class RemoveLastSymbolsOperation : IOperation, IOperationFactory
{
    public int OperationType => 2;

    public int NumberOfSymbolsToRemove { get; set; }

    public void Execute(object parameter)
    {
        var currentText = parameter as StringBuilder;
        if (currentText.Length >= NumberOfSymbolsToRemove)
        {
            currentText.Length -= NumberOfSymbolsToRemove;
        }
    }

    public IOperation MakeOperation(string commandInfo)
    {
        var numberOfSymbolsToRemove = int.Parse(
            commandInfo.Split(' ')[1]);

        return new RemoveLastSymbolsOperation { NumberOfSymbolsToRemove = numberOfSymbolsToRemove };
    }
}