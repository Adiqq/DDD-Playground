using System.Collections.Generic;
using Hotel.Logic.Common;

namespace Hotel.Logic
{
    public class Room : AggregateRoot
    {
        public virtual IList<Reservation> Reservations { get; set; }
        public virtual IList<Feature> Features { get; set; }
        public virtual RoomType Type { get; set; }
        public virtual RoomQuality Quality { get; set; }
        public virtual int Capacity { get; set; }

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