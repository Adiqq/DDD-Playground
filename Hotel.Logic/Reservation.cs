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

        public void SetClient(Client client)
        {
        }

        public void AddGuest(Guest guest)
        {
        }

        public void SetRoom(Room room)
        {
        }

        public void SetStartDate(DateTime startDate)
        {
        }

        public void SetEndDate(DateTime endDate)
        {
        }
    }
}