using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var elementsToPutOnStack = input[0];
            var elementsToPopFromStack = input[1];
            var elementToCheck = input[2];

            var elements = Console.ReadLine().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var numbers = new Stack<int>();
            foreach (var element in elements)
            {
                numbers.Push(element);
            }

            for (var i = 0; i < elementsToPopFromStack; ++i)
            {
                numbers.Pop();
            }

            if (numbers.Count > 0)
            {
                if (numbers.Contains(elementToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
