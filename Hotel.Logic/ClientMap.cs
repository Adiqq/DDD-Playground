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
            Map(x => x.EMailAdress);
            Map(x => x.Login);
            Map(x => x.Name);
            Map(x => x.Surname);
        }
    }
}
