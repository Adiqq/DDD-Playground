using System;
using System.Collections.Generic;

namespace Hotel.Logic
{
    public class Reservation : Entity
    {
        public virtual Client Client { get; }
        public virtual IList<Guest> Guests { get; }
        public virtual Room Room { get; }
        public virtual DateTime StartDate { get; }
        public virtual DateTime EndDate { get; }

        public virtual void SetClient(Client client)
        {
        }

        public virtual void AddGuest(Guest guest)
        {
        }

        public virtual void SetRoom(Room room)
        {
        }

        public virtual void SetStartDate(DateTime startDate)
        {
        }

        public virtual void SetEndDate(DateTime endDate)
        {
        }
    }
}