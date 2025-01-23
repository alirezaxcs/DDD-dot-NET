using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wps.Management.Domain.ValueObjects
{
    public record Weight
    {
        public decimal Value { get; set; }
        public Weight(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("invalid weight!");

            Value = value;
        
        }
        public static implicit operator Weight(double value) { return new Weight(value); }
    }
}
