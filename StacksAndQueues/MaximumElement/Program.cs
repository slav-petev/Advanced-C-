using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MaximumElement
{
    public class MaxStack
    {
        private readonly Stack<int> _stack =
            new Stack<int>();

        private int _maxElement = int.MinValue;

        public int MaxElement => _maxElement;

        public void Push(int element)
        {
            if (_stack.Count == 0 || element > _maxElement)
            {
                _stack.Push(_maxElement);
                _stack.Push(element);
                _maxElement = element;
            }
            else
            {
                _stack.Push(element);
            }
        }

        public int Pop()
        {
            var top = _stack.Pop();
            if (top == _maxElement)
            {
                _maxElement = _stack.Pop();
            }

            return top;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var numberOfQueries = int.Parse(Console.ReadLine());
            var sequence = new MaxStack();

            for (var i = 0; i < numberOfQueries; ++i)
            {
                var query = Console.ReadLine();
                ExecuteQuery(query, sequence);
            }
        }

        private static void ExecuteQuery(string query, MaxStack sequence)
        {
            var queryParts = ParseQuery(query);
            var queryType = queryParts[0];
            switch (queryType)
            {
                case 1:
                    sequence.Push(queryParts[1]);
                    break;
                case 2:
                    sequence.Pop();
                    break;
                case 3:
                    Console.WriteLine(sequence.MaxElement);
                    break;
            }
        }

        private static int[] ParseQuery(string query)
        {
            return query.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}
