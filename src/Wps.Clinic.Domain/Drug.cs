using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.SharedKernel;

namespace Wps.Clinic.Domain
{
    public class Drug : Entity<Guid>
    {
        public string Name { get; set; }
        public Drug(Guid id) : base(id)
        {
        }
    }
}
