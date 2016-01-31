namespace Hotel.Logic
{
    public class RoomType : ValueObject<RoomType>
    {
        public static readonly RoomType HotelRoom = new RoomType("HotelRoom");
        public static readonly RoomType ConferenceRoom = new RoomType("ConferenceRoom");
        public static readonly RoomType Restaurant = new RoomType("Restaurant");

        private RoomType()
        {
        }

        public RoomType(string name)
        {
            Name = name;
        }

        public string Name { get; }

        protected override bool EqualsCore(RoomType other)
        {
            return other.Name == Name;
        }

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }
    }
}