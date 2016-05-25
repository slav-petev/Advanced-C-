namespace _12.LegendaryFarming
{
    public class ResourceInfo
    {
        public string Name { get; set; }
        public long Quantity { get; set; }

        public ResourceInfo(string name, long quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}