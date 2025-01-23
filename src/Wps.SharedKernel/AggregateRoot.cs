using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wps.SharedKernel
{
    public abstract class AggregateRoot : Entity<Guid>
    {
        public AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
