using System.Text;

public class AppendTextOperation : IOperation, IOperationFactory
{
    public int OperationType => 1;

    public string TextToAppend { get; set; }

    public void Execute(object parameter)
    {
        var commandParameter = parameter as StringBuilder;
        var currentText = commandParameter;
        currentText.Append(TextToAppend);
    }

    public IOperation MakeOperation(string commandInfo)
    {
        var textToAppend = commandInfo.Split(' ')[1];
        return new AppendTextOperation { TextToAppend = textToAppend };
    }
}