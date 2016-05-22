using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetsOfElements
{
    public class SetsOfElementsExcercise
    {
        public static void Main(string[] args)
        {
            var setsLengths = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();

            var firstSetLength = setsLengths[0];
            var secondSetLength = setsLengths[1];

            var firstSet = CreateSet(firstSetLength);
            var secondSet = CreateSet(secondSetLength);

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }

        private static HashSet<int> CreateSet(int setLength)
        {
            var setOfElements = new HashSet<int>();
            for (var i = 0; i < setLength; ++i)
            {
                setOfElements.Add(int.Parse(Console.ReadLine()));
            }

            return setOfElements;
        }
    }
}
