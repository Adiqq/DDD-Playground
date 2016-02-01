using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Hotel.Logic;
using Xunit;

namespace Hotel.Tests
{
    public class DayDurationSpecs
    {
        [Theory]
        [MemberData("TestDates")]
        public void End_date_must_be_at_least_at_same_day_as_start(DateTime start, DateTime end)
        {
            Action a = () => new DayDuration(start,end);

            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        public static IEnumerable<object[]> TestDates()
        {
            return new []
            {
                new object[] {new DateTime(2016, 2, 10), new DateTime(2016, 2, 9)},
                new object[] {new DateTime(2016, 2, 10, 0, 0, 0), new DateTime(2016, 2, 9, 23, 59, 59)},
            };
        }
        [Theory]
        [MemberData("TestSameDayDates")]
        public void Duration_is_zero(DateTime start, DateTime end)
        {
            var duration = new DayDuration(start, end);

            duration.Days.Should().Be(0);
        }

        public static IEnumerable<object[]> TestSameDayDates()
        {
            return new[]
            {
                new object[] {new DateTime(2016, 2, 10), new DateTime(2016, 2, 10)},
                new object[] {new DateTime(2016, 2, 10, 0, 0, 0), new DateTime(2016, 2, 10, 23, 59, 59)},
            };
        }

        [Theory]
        [MemberData("TestDifferentDays")]
        public void Duration_is_zero(DateTime start, DateTime end, int expectedDays)
        {
            var duration = new DayDuration(start, end);

            duration.Days.Should().Be(expectedDays);
        }

        public static IEnumerable<object[]> TestDifferentDays()
        {
            return new[]
            {
                new object[] {new DateTime(2016, 2, 10), new DateTime(2016, 2, 11), 1},
                new object[] {new DateTime(2016, 2, 10, 0, 0, 0), new DateTime(2016, 2, 11, 23, 59, 59) , 1},
                new object[] {new DateTime(2016, 2, 10), new DateTime(2016, 2, 12), 2},
                new object[] {new DateTime(2016, 2, 10, 0, 0, 0), new DateTime(2016, 2, 12, 23, 59, 59) , 2},
            };
        }
    }
}
