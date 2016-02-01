using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Hotel.Logic
{
    public class RoomMap : ClassMap<Room>
    {
        public RoomMap()
        {
            Id(x => x.Id);
            Map(x => x.Capacity);
            HasMany(x => x.Features)
                .Component(comp =>
                {
                    comp.Map(x => x.Name);
                });
            HasMany(x => x.Reservations);
            Component(x => x.Type, y =>
            {
                y.Map(x => x.Name);
            });
            Component(x => x.Quality, y =>
            {
                y.Map(x => x.Quality);
            });
        }
    }
}
