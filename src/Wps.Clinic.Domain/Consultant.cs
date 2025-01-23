using Wps.SharedKernel;

namespace Wps.Clinic.Domain
{
    public class Consultant : AggregateRoot
    {
        public Consultant(Guid id) : base(id)
        {
        }
    }
}
