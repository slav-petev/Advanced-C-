using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var queueElements = new Queue<long>();
            var elements = new List<long>();

            queueElements.Enqueue(n);
            elements.Add(n);

            while (elements.Count < 50)
            {
                var currentElement = queueElements.Dequeue();
                var firstNumber = currentElement + 1;
                var secondNumber = 2 * currentElement + 1;
                var thirdNumber = currentElement + 2;

                queueElements.Enqueue(firstNumber);
                queueElements.Enqueue(secondNumber);
                queueElements.Enqueue(thirdNumber);

                elements.Add(firstNumber);
                elements.Add(secondNumber);
                elements.Add(thirdNumber);
            }

            for (var i = 0; i < 50; ++i)
            {
                Console.Write($"{elements[i]} ");
            }
        }
    }
}