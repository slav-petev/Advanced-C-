using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace _12.LegendaryFarming
{
    public class Farmer
    {
        
    }

public class LegendaryfarmingExcercise
    {
        private const long LegendaryItemResourceQuantity = 250L;

        private static readonly ResourceFactory _resourceFactory =
            new ResourceFactory();

        public static void Main()
        {
            var valuableResources = new Dictionary<string, Resource>()
            {
                { "shards", new Shards(new ResourceInfo("shards", 0L))  },
                { "fragments", new Fragments(new ResourceInfo("fragments", 0L)) },
                { "motes", new Motes(new ResourceInfo("motes", 0L)) }
            };

            var ordinaryResources = new SortedDictionary<string, Resource>();
            var legendaryItemObtained = false;

            while (!legendaryItemObtained)
            {
                var resourcesInfo = Console.ReadLine().ToLower();
                var resourceInfoParser = new ResourceInfoParser(resourcesInfo);

                var currentResourceInfo = resourceInfoParser.GetNextResourceInfo();
                while (currentResourceInfo != null)
                {
                    var resource = _resourceFactory.CreateResource(currentResourceInfo);
                    if (resource.IsValuable)
                    {
                        AddResourceToResourcesCollection(resource, valuableResources);
                        if (CanObtainLegendaryItem(valuableResources))
                        {
                            Console.WriteLine($"{GetLegendaryItemNameForResource(resource)} obtained!");
                            valuableResources[resource.Name].Quantity -= LegendaryItemResourceQuantity;
                            var sortedValuableResources = valuableResources
                                .OrderByDescending(v => v.Value.Quantity)
                                .ThenBy(v => v.Value.Name)
                                .ToDictionary(key => key.Key, value => value.Value);
                            
                            foreach (var valuableResource in 
                                sortedValuableResources)
                            {
                                Console.WriteLine(valuableResource.Value);
                            }
                            foreach (var ordinaryResource in ordinaryResources)
                            {
                                Console.WriteLine(ordinaryResource.Value);
                            }
                            legendaryItemObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        AddResourceToResourcesCollection(resource, ordinaryResources);
                    }

                    currentResourceInfo = resourceInfoParser.GetNextResourceInfo();
                }
            }
        }

        private static void AddResourceToResourcesCollection(Resource resource,
            IDictionary<string, Resource> resourcesCollection)
        {
            if (resourcesCollection.ContainsKey(resource.Name))
            {
                resourcesCollection[resource.Name].Quantity += resource.Quantity;
            }
            else
            {
                resourcesCollection.Add(resource.Name, resource);
            }
        }

        private static bool CanObtainLegendaryItem(Dictionary<string, Resource> valuableResources)
        {
            return valuableResources.Any(resource => resource.Value.Quantity >= LegendaryItemResourceQuantity);
        }

        private static string GetLegendaryItemNameForResource(Resource resource)
        {
            switch (resource.Name)
            {
                case "shards":
                    return "Shadowmourne";
                case "fragments":
                    return "Valanyr";
                case "motes":
                    return "Dragonwrath";
                default:
                    return string.Empty;
            }
        }
    }
}
