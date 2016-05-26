using System;

namespace _12.LegendaryFarming.ResourcesInfoCollectors
{
    public class ConsoleResourcesInfoCollector : IResourcesInfoCollector
    {
        public string GetResourcesInfo()
        {
            return Console.ReadLine().ToLower();
        }
    }
}