using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PeriodicTable
{
    public class PeriodicTableExcercise
    {
        public static void Main(string[] args)
        {
            var chemicalCompoundsCount = int.Parse(Console.ReadLine());

            var uniqueCompounds = new SortedSet<string>();

            for (var i = 0; i < chemicalCompoundsCount; ++i)
            {
                var compounds = Console.ReadLine().Split(' ');
                foreach (var compound in compounds)
                {
                    uniqueCompounds.Add(compound);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueCompounds));
        }
    }
}
