using System;
using System.Collections.Generic;
using Hotel;
using Hotel.Logic;
using Hotel.Logic.Utils;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Hotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Initer.Init(@"Server=ADWA;Database=Hotel;Trusted_Connection=true");

            var clientData = new ClientData("test", "test", "test", "test");
            var client = new Client { ClientData = clientData };
            var repo = new ClientRepository();
            repo.Save(client);

            var features = new List<Feature>();
            features.Add(Feature.Bathroom);
            var room = new Room { Quality = RoomQuality.Average, Features = features, Type = RoomType.HotelRoom };
            room.SetCapacity(5);

            var roomRepo = new RoomRepository();
            roomRepo.Save(room);

            var features2 = new List<Feature>();
            features2.Add(Feature.Bathroom);
            features2.Add(Feature.Tv);
            var room2 = new Room { Quality = RoomQuality.Good, Features = features2, Type = RoomType.HotelRoom };
            room2.SetCapacity(2);

            roomRepo.Save(room2);

            var duration = new DayDuration(DateTime.Now, DateTime.Now.AddDays(1));
            var reservation = new Reservation(client, room, duration);
            var reservationRepo = new ReservationRepository();
            reservationRepo.Save(reservation);
        }
    }
}