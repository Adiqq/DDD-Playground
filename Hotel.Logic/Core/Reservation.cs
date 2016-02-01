using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hotel.Logic.Common;

namespace Hotel.Logic
{
    public class Reservation : AggregateRoot
    {
        public virtual Client Client { get; protected set; }
        public virtual ISet<Guest> Guests { get; protected set; }
        public virtual Room Room { get; protected set; }
        public virtual DayDuration Duration { get; protected set; }

        protected Reservation()
        {
        }

        public Reservation(Client client, Room room, DayDuration duration)
        {
            Client = client;
            Room = room;
            SetDuration(duration);
            Guests = new HashSet<Guest>();
        }

        public virtual void AddGuest(Guest guest)
        {
            if (Guests.Add(guest) == false)
            {
                throw new InvalidOperationException();
            }
        }

        public virtual void SetDuration(DayDuration duration)
        {
            if(duration.Days == 0)
                throw new ArgumentOutOfRangeException();
            Duration = duration;
        }
    }
}