using System;

public class SimpleTextEditorController
{
    public void Run()
    {
        var numberOfOperations = int.Parse(Console.ReadLine());
        var textEditor = new SimpleTextEditor();

        for (var i = 0; i < numberOfOperations; ++i)
        {
            var operation = Console.ReadLine();
            textEditor.ExecuteCurrentOperation(operation);
        }
    }
}