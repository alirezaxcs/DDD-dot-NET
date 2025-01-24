using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wps.Clinic.Domain.ValueObject
{
    public record VitalSigns
    {
        public VitalSigns(DateTime readingDateTime, decimal temprature, int respeiratoryRate, int heartRate)
        {
            ReadingDateTime = readingDateTime;
            Temprature = temprature;
            RespeiratoryRate = respeiratoryRate;
            HeartRate = heartRate;
        }

        public DateTime ReadingDateTime { get; init; }
        public decimal Temprature { get; init; } 
        public int RespeiratoryRate { get; init; }
        public int HeartRate { get; init; }
    }
}
