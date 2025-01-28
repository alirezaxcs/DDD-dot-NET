using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.Clinic.Domain.ValueObject;
using Wps.SharedKernel;

namespace Wps.Clinic.Domain.Events
{
    public record ConsultaionStarted(Guid Id,PatientId PatientId,DateTime StartedAt):IDomainEvent;
    
    
}
