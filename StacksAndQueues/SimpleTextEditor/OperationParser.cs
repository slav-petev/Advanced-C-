using System.Collections.Generic;
using System.Linq;

public class OperationParser
{
    private readonly IEnumerable<IOperationFactory> _availableOperations;

    public OperationParser(IEnumerable<IOperationFactory> availableOperations)
    {
        _availableOperations = availableOperations;
    }

    public IOperation ParseCommand(string commandInfo)
    {
        var commandInfoParts = commandInfo.Split(' ');
        var requestedCommandType = int.Parse(commandInfoParts[0]);
        var command = FindRequestedCommand(requestedCommandType);

        return command.MakeOperation(commandInfo);
    }

    private IOperationFactory FindRequestedCommand(int operationType)
    {
        return _availableOperations
            .FirstOrDefault(command => command.OperationType == operationType);
    }
}