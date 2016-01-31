using System.Collections.Generic;

namespace Hotel.Logic
{
    public class Room : Entity
    {
        public virtual IList<Reservation> Reservations { get; }
        public virtual IList<Feature> Features { get; }
        public virtual RoomType Type { get; }
        public virtual RoomQuality Quality { get; }
        public virtual int Capacity { get; }

        public virtual void AddReservation(Reservation reservation)
        {
        }

        public virtual void AddFeature(Feature feature)
        {
        }

        public virtual void SetCapacity(int capacity)
        {
        }

        public virtual void SetType(RoomType type)
        {
        }

        public virtual void SetQuality(RoomQuality quality)
        {
        }
    }
}