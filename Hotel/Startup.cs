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
            Initer.Init(@"Server=.\SQLEXPRESS;Database=Hotel;Trusted_Connection=true");

            var client = new Client { EMailAdress = "test", Login = "test", Name = "test", Surname = "test" };
            var repo = new ClientRepository();
            repo.Save(client);

            var features = new List<Feature>();
            features.Add(Feature.Bathroom);
            var room = new Room { Capacity = 5, Quality = RoomQuality.Average, Features = features, Type = RoomType.HotelRoom };
            var roomRepo = new RoomRepository();
            roomRepo.Save(room);
            var features2 = new List<Feature>();
            features2.Add(Feature.Bathroom);
            features2.Add(Feature.Tv);
            var room2 = new Room { Capacity = 2, Quality = RoomQuality.Good, Features = features2, Type = RoomType.HotelRoom };
            roomRepo.Save(room2);

            var reservation = new Reservation()
            {
                Client = client,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Room = room
            };
            var reservationRepo = new ReservationRepository();
            reservationRepo.Save(reservation);
        }
    }
}