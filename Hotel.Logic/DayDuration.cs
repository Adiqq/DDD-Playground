using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Logic
{
    public sealed class DayDuration : ValueObject<DayDuration>
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public int Days => (EndDate.Date - StartDate.Date).Days;

        private DayDuration()
        {
        }

        public DayDuration(DateTime startDay, DateTime endDay)
        {
            if(startDay.Date > endDay.Date)
                throw new ArgumentOutOfRangeException();
            StartDate = startDay;
            EndDate = endDay;
        }

        protected override bool EqualsCore(DayDuration other)
        {
            return other.StartDate.Date == StartDate.Date &&
                   other.EndDate.Date == EndDate.Date;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = StartDate.GetHashCode();
                hashCode = (hashCode * 397) ^ EndDate.GetHashCode();
                return hashCode;
            }
        }
    }
}
