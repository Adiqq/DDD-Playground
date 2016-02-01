using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.DTO;
using Hotel.Logic.Common;
using Hotel.Logic.Utils;
using NHibernate.Linq;

namespace Hotel.Logic
{
    public class RoomRepository : Repository<Room>
    {
        public IEnumerable<RoomDTO> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                return session.Query<Room>().ToList().Select(
                    x => new RoomDTO
                    {
                        Capacity = x.Capacity,
                        Features = x.Features.Select(y => y.Name),
                        Quality = x.Quality.Quality.ToString(),
                        Type = x.Type.Name.ToString(),
                    }
                    );
            }
        }
    }
}
