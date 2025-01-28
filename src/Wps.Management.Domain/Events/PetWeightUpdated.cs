using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.SharedKernel;

namespace Wps.Management.Domain.Events
{
   public record PetWeightUpdated(Guid Id, decimal Weight): IDomainEvent;
    
}
