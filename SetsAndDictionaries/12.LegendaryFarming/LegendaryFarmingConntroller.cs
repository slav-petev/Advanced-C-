using System;

namespace _12.LegendaryFarming
{
    public class LegendaryFarmingConntroller
    {
        private readonly ResourceInfoParser _resourceInfoParser =
            new ResourceInfoParser();

        private readonly ResourceFactory _resourceFactory =
            new ResourceFactory();

        private readonly Farmer _farmer = new Farmer();

        public void Run()
        {
            while (!_farmer.HasObtainedLegendaryItem)
            {
                var resourcesInfo = Console.ReadLine().ToLower();
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