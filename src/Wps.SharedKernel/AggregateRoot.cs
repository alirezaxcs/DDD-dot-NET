using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wps.SharedKernel
{
    public abstract class AggregateRoot : Entity<Guid>
    {
        protected AggregateRoot():base(Guid.NewGuid())
        {
            
        }
        protected AggregateRoot(Guid Id) : base(Id)
        {

        }
        private readonly List<IDomainEvent> _changes = new List<IDomainEvent>();

        public int Version { get; private set; }

        public IReadOnlyCollection<IDomainEvent> GetChanges()
        {
            return _changes.AsReadOnly();
        }
         
        public void ClearChanges()
        {
            _changes.Clear();
        }

        protected void ApplyDomainEvent(IDomainEvent domainEvent)
        {
            ChangeStateByUsingDomainEvent(domainEvent);
            _changes.Add(domainEvent);
            Version++;
        }
        public void Load(IEnumerable<IDomainEvent> history)
        {
            foreach (IDomainEvent domainEvent in history) 
            { ApplyDomainEvent(domainEvent); }
            ClearChanges();
        }
        protected abstract void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent);
    }
}
