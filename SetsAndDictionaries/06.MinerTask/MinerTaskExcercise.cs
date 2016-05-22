using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (resourcesInfo.ContainsKey(resourceName))
                {
                    resourcesInfo[resourceName] += resourceQuantity;
                }
                else
                {
                    resourcesInfo.Add(resourceName, resourceQuantity);
                }

                resourceName = Console.ReadLine();
            }

            foreach (var resource in resourcesInfo)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
