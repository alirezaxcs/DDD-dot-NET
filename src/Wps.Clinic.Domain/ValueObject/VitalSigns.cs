﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.SharedKernel;

namespace Wps.Clinic.Domain.ValueObject
{
    public class VitalSigns:Entity<Guid>
    {
        public VitalSigns() : base(Guid.NewGuid())
        {
                
        }
        public VitalSigns(Guid consultantId, DateTime readingDateTime, decimal temprature, int respeiratoryRate, int heartRate):base(Guid.NewGuid())
        {
            ConsultantId = consultantId;
            ReadingDateTime = readingDateTime;
            Temprature = temprature;
            RespeiratoryRate = respeiratoryRate;
            HeartRate = heartRate;
        }
        public Guid ConsultantId { get; set; }
        public DateTime ReadingDateTime { get; init; }
        public decimal Temprature { get; init; } 
        public int RespeiratoryRate { get; init; }
        public int HeartRate { get; init; }
    }
}
