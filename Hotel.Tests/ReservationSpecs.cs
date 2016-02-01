using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Common;
using Hotel.Logic;
using Xunit;
using Moq;

namespace Hotel.Tests
{
    public class ReservationSpecs
    {
        [Theory]
        [MemberData("TestDates")]
        public void Duration_must_be_at_least_one_day(DateTime start, DateTime end)
        {
            var duration = new DayDuration(start, end);
            Action a = () => new Reservation(null, null, duration);

            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        public static IEnumerable<object[]> TestDates()
        {
            return new[]
            {
                new object[] {new DateTime(2016, 2, 10), new DateTime(2016, 2, 10)},
                new object[] {new DateTime(2016, 2, 10, 0, 0, 0), new DateTime(2016, 2, 10, 23, 59, 59) }
            };
        }

        [Fact]
        public void Cant_add_two_same_guests()
        {
            var duration = new DayDuration(new DateTime(2016, 2, 10), new DateTime(2016, 2, 11));
            var reservation = new Reservation(null, null, duration);
            var guestOne = new Guest("Test", "Test");
            var guestTwo = new Guest("Test", "Test");
            reservation.AddGuest(guestOne);
            reservation.Invoking(x => x.AddGuest(guestTwo)).ShouldThrow<InvalidOperationException>();
        }

    }
}
