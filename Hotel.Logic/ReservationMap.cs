using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Hotel.Logic
{
    public class ReservationMap : ClassMap<Reservation>
    {
        public ReservationMap()
        {
            Id(x => x.Id);
            References(x => x.Client).Not.LazyLoad();
            References(x => x.Room).Not.LazyLoad();
            HasMany(x => x.Guests)
                .Component(comp =>
                {
                    comp.Map(x => x.Name);
                    comp.Map(x => x.Surname);
                });
            Map(x => x.EndDate);
            Map(x => x.StartDate);
        }
    }
}
