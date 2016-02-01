using System.Collections;
using System.Collections.Generic;
using Hotel.Logic.Common;

namespace Hotel.Logic
{
    public class Client : AggregateRoot
    {
        public virtual ClientData ClientData { get; set; }
        public virtual IList<Reservation> Reservations { get; protected set; }
    }
}