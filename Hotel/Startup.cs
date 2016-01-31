using Hotel;
using Hotel.Logic;
using Hotel.Logic.Utils;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace Hotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Initer.Init(@"Server=.\SQLEXPRESS;Database=Hotel;Trusted_Connection=true");

            var client = new Client {EMailAdress = "test", Login = "test", Name = "test", Surname = "test"};
            var repo = new ClientRepository();
            repo.Save(client);
        }
    }
}