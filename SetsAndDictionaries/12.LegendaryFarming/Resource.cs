namespace _12.LegendaryFarming
{
    public abstract class Resource
    {
        public long Quantity { get; set; }

        public string Name { get; }
        public abstract bool IsValuable { get; }

        protected Resource(ResourceInfo resourceInfo)
        {
            Name = resourceInfo.Name;
            Quantity = resourceInfo.Quantity;
        }

        public override string ToString()
        {
            return ToStringInternal();
        }

        protected virtual string ToStringInternal()
        {
            return $"{Name}: {Quantity}";
        }
    }
}