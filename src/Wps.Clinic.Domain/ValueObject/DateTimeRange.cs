using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wps.Clinic.Domain.ValueObject
{
    public record DateTimeRange
    {
        public DateTime Start { get; init; }
        public DateTime? End { get; init; }

        public DateTimeRange(DateTime start)
        {
            Start = start;
        }
        public DateTimeRange(DateTime start, DateTime end)
        {
            ValidateRange(start, end);

            Start = start;
            End = end;
        }

        private  void ValidateRange(DateTime start, DateTime end)
        {
            if (end <= start)
            {
                throw new InvalidOperationException("End time must be after start time.");
            }
        }
        public static implicit operator DateTimeRange(DateTime dateTime)
        { return new DateTimeRange(dateTime); }

        public string Duration => End == null ? "Ongoing" :
            "Duratition Days: " + (End.Value - Start).Days +
            " Hours: " + (End.Value - Start).Days;
    }
}
