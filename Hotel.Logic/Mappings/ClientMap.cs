using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Hotel.Logic
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(x => x.Id);
            Component(x => x.ClientData, y =>
            {
                y.Map(x => x.Login);
                y.Map(x => x.EMailAdress);
                y.Map(x => x.Name);
                y.Map(x => x.Surname);
            });
        }
    }
}
