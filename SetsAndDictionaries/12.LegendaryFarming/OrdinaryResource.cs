namespace _12.LegendaryFarming
{
    public class OrdinaryResource : Resource
    {
        public override bool IsValuable => false;

        public OrdinaryResource(ResourceInfo resourceInfo) : base(resourceInfo)
        {
        }
    }
}