using System;
using System.Collections.Generic;
using Hotel.Logic.Common;

namespace Hotel.Logic
{
    public class Reservation : AggregateRoot
    {
        public virtual Client Client { get; set; }
        public virtual IList<Guest> Guests { get; set; }
        public virtual Room Room { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }

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