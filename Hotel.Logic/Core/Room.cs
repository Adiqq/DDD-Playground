using System;
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
        public virtual int Capacity { get; protected set; }

        public virtual void SetCapacity(int capacity)
        {
            if(capacity <= 0)
                throw new ArgumentOutOfRangeException();
            Capacity = capacity;
        }
    }
}