using System;
using _12.LegendaryFarming.ResourcesInfoCollectors;

namespace _12.LegendaryFarming
{
    public class LegendaryFarmingConntroller
    {
        private readonly IResourcesInfoCollector _resourcesInfoCollector =
            new ConsoleResourcesInfoCollector();

        private readonly ResourceInfoParser _resourceInfoParser =
            new ResourceInfoParser();

        private readonly ResourceFactory _resourceFactory =
            new ResourceFactory();

        private readonly Farmer _farmer = new Farmer();

        public void Run()
        {
            while (!_farmer.HasObtainedLegendaryItem)
            {
                var resourcesInfo = _resourcesInfoCollector.GetResourcesInfo();
                _resourceInfoParser.LoadResourcesInfo(resourcesInfo);

                var currentResourceInfo = _resourceInfoParser.GetNextResourceInfo();
                while (currentResourceInfo != null)
                {
                    var resource = _resourceFactory.CreateResource(currentResourceInfo);
                    _farmer.CollectResource(resource);
                    if (_farmer.CanObtainLegendaryItem)
                    {
                        _farmer.ObtainLegendaryItem(resource);
                        _farmer.PrintStats();
                    }

                    currentResourceInfo = _resourceInfoParser.GetNextResourceInfo();
                }
            }
        }
    }
}