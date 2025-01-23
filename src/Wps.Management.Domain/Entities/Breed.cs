using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.SharedKernel;

namespace Wps.Management.Domain.Entities
{
    public record WeightRage(decimal From, decimal To);

    public class Breed : Entity<Guid>
    {
        public string Name { get; init; }
        public WeightRage MaleIdealRange { get; init; }
        public WeightRage FemaleIdealRange { get; init; }

        public Breed(Guid id, WeightRage maleIdealRange, WeightRage femaleIdealRange, string name) : base(id)
        {
            MaleIdealRange = maleIdealRange;
            FemaleIdealRange = femaleIdealRange;
            Name = name;
        }
    }
}
