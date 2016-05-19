using System;
using System.Collections.Generic;
using System.Security.Policy;

public class ParenthesesbalancedChecker
{
    public static void Main()
    {
        var expression = Console.ReadLine();
        var openingParenthesesStack = new Stack<char>();
        var isExpressionBalanced = true;

        var index = 0;
        while (index < expression.Length && isExpressionBalanced)
        {
            var currentSymbol = expression[index];
            if (IsOpeningParentheses(currentSymbol))
            {
                openingParenthesesStack.Push(currentSymbol);
            }
            else
            {
                if (openingParenthesesStack.Count == 0)
                {
                    isExpressionBalanced = false;
                }
                else
                {
                    var currentOpeningparentheses = openingParenthesesStack.Pop();
                    if (!AreParenthesesMatched(currentOpeningparentheses, currentSymbol))
                    {
                        isExpressionBalanced = false;
                    }
                }
            }
            ++index;
        }

        Console.WriteLine(isExpressionBalanced ? "YES" : "NO");
    }

    private static bool IsOpeningParentheses(char parentheses)
    {
        return parentheses == '(' || parentheses == '[' || parentheses == '{';
    }

    private static bool AreParenthesesMatched(char openingParentheses, char closingParentheses)
    {
        return (openingParentheses == '(' && closingParentheses == ')') ||
            (openingParentheses == '[' && closingParentheses == ']') ||
            (openingParentheses == '{' && closingParentheses == '}');
    }
}
