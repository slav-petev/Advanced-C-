using System.Collections.Generic;
using System.Text;

public class SimpleTextEditor
{
    private readonly OperationParser _operationParser =
        new OperationParser(GetAvailableCommands());

    private readonly StringBuilder _text =
        new StringBuilder();

    private readonly Stack<string> _previousTextStates =
        new Stack<string>();

    public string Text => _text.ToString();

    public void ExecuteCurrentOperation(string commandInfo)
    {
        
        var command = _operationParser.ParseCommand(commandInfo);
        if (command is UndoLastOperation)
        {
            _text.Clear();
            _text.Append(_previousTextStates.Pop());
        }
        else
        {
            var previousTextState = Text;
            command.Execute(_text);
            if (Text != previousTextState)
            {
                _previousTextStates.Push(previousTextState);
            }
        }
    }

    public override string ToString()
    {
        return Text;
    }

    private static IEnumerable<IOperationFactory> GetAvailableCommands()
    {
        return new IOperationFactory[]
        {
            new AppendTextOperation(),
            new RemoveLastSymbolsOperation(),
            new PrintSymbolAtPositionOperation(),
            new UndoLastOperation(),   
        };
    }
}