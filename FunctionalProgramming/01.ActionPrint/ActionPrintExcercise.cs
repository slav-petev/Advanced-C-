using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPrint
{
    public class ActionPrintExcercise
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .ToList();
            input.ForEach(Console.WriteLine);
        }
    }
}
