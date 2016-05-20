using System;
using System.Text;

public class PrintSymbolAtPositionOperation : IOperation, IOperationFactory
{
    public int OperationType => 3;

    public int SymbolPosition { get; set; }

    public void Execute(object parameter)
    {
        var currentText = parameter as StringBuilder;
        Console.WriteLine(currentText[SymbolPosition - 1]);
    }

    public IOperation MakeOperation(string commandInfo)
    {
        var symbolPosition = int.Parse(
            commandInfo.Split(' ')[1]);

        return new PrintSymbolAtPositionOperation { SymbolPosition = symbolPosition };
    }
}