using System;
using System.Collections.Generic;

public class StackFibonacciCalculator
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine(CalculateFibonnaciNumber(n));
    }

    private static long CalculateFibonnaciNumber(int n)
    {
        if (n == 1 || n == 2)
        {
            return 1L;
        }
        var fibonnaciStack = new Stack<long>();
        fibonnaciStack.Push(1);
        fibonnaciStack.Push(1);

        for (var i = 3; i <= n; ++i)
        {
            var firstPreviousFibonacciNumber = fibonnaciStack.Pop();
            var secondPreviousFibonacciNumber = fibonnaciStack.Peek();
            fibonnaciStack.Push(firstPreviousFibonacciNumber);
            fibonnaciStack.Push(firstPreviousFibonacciNumber + secondPreviousFibonacciNumber);
        }

        return fibonnaciStack.Peek();
    }
}