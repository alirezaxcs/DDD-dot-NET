using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wps.Clinic.Domain.ValueObject
{
    public record DrugId
    {
        public Guid Value { get; init; }

        public DrugId(Guid value)
        {
            Value = value;
        }
    }
}
