using System.Collections;
using System.Collections.Generic;
using Hotel.Logic.Common;

namespace Hotel.Logic
{
    public class Client : AggregateRoot
    {
        public virtual string Login { get; set; }
        public virtual string EMailAdress { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual IList<Reservation> Reservations { get; }
    }
}