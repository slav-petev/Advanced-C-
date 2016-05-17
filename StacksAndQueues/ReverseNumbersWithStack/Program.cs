using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumbersWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(
                new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var reversedInput = Reverse(input);
            Console.WriteLine(reversedInput);
        }

        private static string Reverse(int[] input)
        {
            var inputStack = new Stack<int>();
            foreach (var element in input)
            {
                inputStack.Push(element);
            }
            
            return string.Join(" ", inputStack.ToArray());
        }
    }
}
