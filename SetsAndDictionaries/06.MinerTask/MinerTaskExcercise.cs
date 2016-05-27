using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryExtensions;

namespace _06.MinerTask
{
    public class MinerTaskExcercise
    {
        public static void Main(string[] args)
        {
            var resourcesInfo = new Dictionary<string, long>();

            var resourceName = Console.ReadLine();

            while (resourceName != "stop")
            {
                var resourceQuantity = long.Parse(Console.ReadLine());

                resourcesInfo.AddOrUpdate(resourceName, resourceQuantity,
                    () => resourcesInfo[resourceName] += resourceQuantity);

                resourceName = Console.ReadLine();
            }

            foreach (var resource in resourcesInfo)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
