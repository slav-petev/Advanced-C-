using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.KnightsOfHpnor
{
    public class KnightsOfHonorExcercise
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(new[] { ' ' } , 
                StringSplitOptions.RemoveEmptyEntries)
            .ToList();

            names.ForEach(name => Console.WriteLine($"Sir {name}"));
        }
    }
}
