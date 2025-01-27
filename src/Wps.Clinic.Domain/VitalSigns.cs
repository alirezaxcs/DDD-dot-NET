using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.SharedKernel;

namespace Wps.Clinic.Domain
{
    public class VitalSigns : Entity<Guid>
    {
        public VitalSigns() : base(Guid.NewGuid())
        {

        }
        public VitalSigns(
            DateTime readingDateTime, 
            decimal temprature, 
            int respeiratoryRate,
            int heartRate) : base(Guid.NewGuid())
        {
          
            ReadingDateTime = readingDateTime;
            Temprature = temprature;
            RespeiratoryRate = respeiratoryRate;
            HeartRate = heartRate;
        }
        public Guid ConsultantId { get; init; }
        public DateTime ReadingDateTime { get; init; }
        public decimal Temprature { get; init; }
        public int RespeiratoryRate { get; init; }
        public int HeartRate { get; init; }
    }
}
