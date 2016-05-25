using System;
using System.Collections.Generic;

namespace _12.LegendaryFarming
{
    public class ResourceFactory
    {
        private readonly Dictionary<string, Func<ResourceInfo, Resource>> _resourceConstructors =
            new Dictionary<string, Func<ResourceInfo, Resource>>();

        public ResourceFactory()
        {
            _resourceConstructors.Add("shards", (resourceInfo) => new Shards(resourceInfo));
            _resourceConstructors.Add("fragments", (resourceInfo) => new Fragments(resourceInfo));
            _resourceConstructors.Add("motes", (resourceInfo) => new Motes(resourceInfo));
            _resourceConstructors.Add(string.Empty, (resourceInfo) => new OrdinaryResource(resourceInfo));
        }

        public Resource CreateResource(ResourceInfo resourceInfo)
        {
            var resourceConstructor = _resourceConstructors.ContainsKey(resourceInfo.Name)
                ? _resourceConstructors[resourceInfo.Name]
                : _resourceConstructors[string.Empty];

            return resourceConstructor(resourceInfo);
        }
    }
}