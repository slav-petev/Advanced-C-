using System;
using System.Collections.Generic;

public class RecursiveFibonacciCalculator
{
    private static readonly Dictionary<int, long> _lookupTable =
        new Dictionary<int, long>();

    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculateFibonnaciNumber(n));
    }

    private static long CalculateFibonnaciNumber(int n)
    {
        if (n == 0)
        {
            return 0L;
        }
        if (n == 1)
        {
            return 1L;
        }

        if (_lookupTable.ContainsKey(n))
        {
            return _lookupTable[n];
        }
        var currentFibonacciNumber = CalculateFibonnaciNumber(n - 1) + CalculateFibonnaciNumber(n - 2);
        _lookupTable[n] = currentFibonacciNumber;
        return currentFibonacciNumber;
    }
}