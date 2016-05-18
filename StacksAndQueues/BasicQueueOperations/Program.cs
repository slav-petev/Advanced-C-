using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var numberOfElementsToEnque = input[0];
            var numberOfElementsToDeque = input[1];
            var elementToCheck = input[2];

            var queue = new Queue<int>();
            var elementsToEnqueue = ReadElementsToEnqueue(numberOfElementsToEnque);
            EnqueueElements(queue, elementsToEnqueue);
            DequeueElements(queue, numberOfElementsToDeque);
            CheckElement(queue, elementToCheck);
        }

        private static int[] ReadElementsToEnqueue(int numberOfElementsToEnqueue)
        {
            var elementsToEnqueue = Console.ReadLine();
            
            return elementsToEnqueue.Trim().Split(
                new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        private static void EnqueueElements(Queue<int> queue, int[] elementsToEnqueue)
        {
            foreach (var elementToEnqueue in elementsToEnqueue)
            {
                queue.Enqueue(elementToEnqueue);
            }
        }

        private static void DequeueElements(Queue<int> queue, int numberOfElementsToDequeue)
        {
            for (var i = 0; i < numberOfElementsToDequeue; ++i)
            {
                queue.Dequeue();
            }
        }

        private static void CheckElement(Queue<int> queue, int elementToCheck)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("0");    
            }
            else if (queue.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
