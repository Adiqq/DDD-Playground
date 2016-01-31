namespace Hotel.Logic
{
    public sealed class Feature : ValueObject<Feature>
    {
        public static readonly Feature Bathroom = new Feature("Bathroom");
        public static readonly Feature Tv = new Feature("TV");

        private Feature()
        {
        }

        public Feature(string name)
        {
            Name = name;
        }

        public string Name { get; }

        protected override bool EqualsCore(Feature other)
        {
            return other.Name == Name;
        }

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }
    }
}