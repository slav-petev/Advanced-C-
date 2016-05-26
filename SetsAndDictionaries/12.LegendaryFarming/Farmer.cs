using System;
using System.Collections.Generic;
using System.Linq;
using _12.LegendaryFarming.ExtensionMethods;

namespace _12.LegendaryFarming
{
    public class Farmer
    {
        private readonly Dictionary<string, Resource> _valuableResources = 
            new Dictionary<string, Resource>
            {
                { Constants.Shards, new Shards(new ResourceInfo(Constants.Shards, 0L))  },
                { Constants.Fragments, new Fragments(new ResourceInfo(Constants.Fragments, 0L)) },
                { Constants.Motes, new Motes(new ResourceInfo(Constants.Motes, 0L)) }
            };

        private readonly SortedDictionary<string, Resource> _ordinaryResources =
            new SortedDictionary<string, Resource>();

        public string LegendaryItemName { get; private set; }

        public bool HasObtainedLegendaryItem { get; private set; }

        public bool CanObtainLegendaryItem => _valuableResources.Any(resource =>
            resource.Value.Quantity >= Constants.LegendaryItemResourceCost);

        

        public void CollectResource(Resource resource)
        {
            if (resource.IsValuable)
            {
                _valuableResources.AddOrUpdate(resource.Name, resource);
            }
            else
            {
                _ordinaryResources.AddOrUpdate(resource.Name, resource);
            }
        }

        public void ObtainLegendaryItem(Resource resource)
        {
            _valuableResources[resource.Name].Quantity -= Constants.LegendaryItemResourceCost;
            LegendaryItemName = "Random";
            HasObtainedLegendaryItem = true;
        }

        public void PrintStats()
        {
            Console.WriteLine($"{LegendaryItemName} obtained!");
            PrintValuableResources();
            PrintOrdinaryResources();
            
        }

        private void PrintValuableResources()
        {
            var sortedValuableResources = _valuableResources
                .OrderByDescending(resource => resource.Value.Quantity)
                .ThenBy(resource => resource.Key)
                .ToDictionary(key => key.Key, value => value.Value);

            foreach (var valuableResource in sortedValuableResources)
            {
                Console.WriteLine(valuableResource.Value);
            }
        }

        private void PrintOrdinaryResources()
        {
            foreach (var ordinaryResource in _ordinaryResources)
            {
                Console.WriteLine(ordinaryResource.Value);
            }
        }
    }
}