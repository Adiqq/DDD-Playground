namespace Hotel.Logic
{
    public sealed class RoomQuality : ValueObject<RoomQuality>
    {
        public static readonly RoomQuality None = new RoomQuality("None");
        public static readonly RoomQuality Poor = new RoomQuality("Poor");
        public static readonly RoomQuality Average = new RoomQuality("Average");
        public static readonly RoomQuality Good = new RoomQuality("Good");


        private RoomQuality()
        {
        }
        private RoomQuality(string quality)
        {
            Quality = quality;
        }

        public string Quality { get; }

        protected override bool EqualsCore(RoomQuality other)
        {
            return other.Quality == Quality;
        }

        protected override int GetHashCodeCore()
        {
            return Quality.GetHashCode();
        }
    }
}