using System.Collections.Generic;

namespace _12.LegendaryFarming.ExtensionMethods
{
    public static class DictionaryExtensionMethods
    {
        public static void AddOrUpdate(this Dictionary<string, Resource> dictionary,
            string resourceName, Resource resourceQuantity)
        {
            if (dictionary.ContainsKey(resourceName))
            {
                dictionary[resourceName].Quantity += resourceQuantity.Quantity;
            }
            else
            {
                dictionary.Add(resourceName, resourceQuantity);
            }
        }
    }
}