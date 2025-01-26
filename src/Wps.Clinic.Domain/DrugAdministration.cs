using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.Clinic.Domain.ValueObject;
using Wps.SharedKernel;

namespace Wps.Clinic.Domain
{
    public class DrugAdministration : Entity<Guid>
    {
        public DrugId DrugId { get; init; }
        public Dose Dose { get; init; }
        public DrugAdministration() : base(Guid.NewGuid())
        {
            
        }
        public DrugAdministration( DrugId drugId, Dose dose) : base(Guid.NewGuid())
        {
            DrugId = drugId;
            Dose = dose;
        }
    }
}
