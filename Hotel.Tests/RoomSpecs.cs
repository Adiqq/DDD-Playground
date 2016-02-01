using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Hotel.Logic;
using Xunit;

namespace Hotel.Tests
{
    public class RoomSpecs
    {
        [Fact]
        public void Create_room()
        {
            var room = new Room();
            room.SetCapacity(1);
            room.Quality = RoomQuality.Average;
            room.Type = RoomType.HotelRoom;
            room.Features = null;
            room.Reservations = null;
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(0)]
        public void Cant_create_room_with_non_positive_capacity(int capacity)
        {
            var room = new Room();
            room.Invoking(y => y.SetCapacity(capacity))
                .ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}

