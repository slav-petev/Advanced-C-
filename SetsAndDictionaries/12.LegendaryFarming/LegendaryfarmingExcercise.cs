using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace _12.LegendaryFarming
{
    public class LegendaryfarmingExcercise
{
    private static readonly ResourceFactory _resourceFactory =
            new ResourceFactory();

        public static void Main()
        {
            var farmer = new Farmer();

            var legendaryItemObtained = false;

            while (!legendaryItemObtained)
            {
                var resourcesInfo = Console.ReadLine().ToLower();
                var resourceInfoParser = new ResourceInfoParser(resourcesInfo);

                var currentResourceInfo = resourceInfoParser.GetNextResourceInfo();
                while (currentResourceInfo != null)
                {
                    var resource = _resourceFactory.CreateResource(currentResourceInfo);
                    farmer.AddResource(resource);
                    if (farmer.CanObtainLegendaryItem)
                    {
                        farmer.ObtainLegendaryItem(resource);
                        farmer.PrintStats();
                        legendaryItemObtained = true;
                    }
                    //if (resource.IsValuable)
                    //{
                    //    AddResourceToResourcesCollection(resource, valuableResources);
                    //    if (CanObtainLegendaryItem(valuableResources))
                    //    {
                    //        Console.WriteLine($"{GetLegendaryItemNameForResource(resource)} obtained!");
                    //        valuableResources[resource.Name].Quantity -= Constants.LegendaryItemResourceCost;
                    //        var sortedValuableResources = valuableResources
                    //            .OrderByDescending(v => v.Value.Quantity)
                    //            .ThenBy(v => v.Value.Name)
                    //            .ToDictionary(key => key.Key, value => value.Value);
                            
                    //        foreach (var valuableResource in 
                    //            sortedValuableResources)
                    //        {
                    //            Console.WriteLine(valuableResource.Value);
                    //        }
                    //        foreach (var ordinaryResource in ordinaryResources)
                    //        {
                    //            Console.WriteLine(ordinaryResource.Value);
                    //        }
                    //        legendaryItemObtained = true;
                    //        break;
                    //    }
                    //}
                    //else
                    //{
                    //    AddResourceToResourcesCollection(resource, ordinaryResources);
                    //}

                    currentResourceInfo = resourceInfoParser.GetNextResourceInfo();
                }
            }
        }
    }
}
