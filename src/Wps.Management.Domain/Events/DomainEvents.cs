using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.SharedKernel;

namespace Wps.Management.Domain.Events
{
    public static class DomainEvents
    {
        public static DomainEventDispatcher<PetWeightUpdated> PetWeightUpdated = new();
    }

    //public static class DomainEventsGeneric
    //{
    //    private static readonly List<DomainEventDispatcher<DomainEvent>> _dispatchers = new();

    //    public static void Publish<T>(T eventObject) where T : IDomainEvent
    //    {

    //        if (!_dispatchers.Any(d => d.GetType() == typeof(DomainEventDispatcher<T>)))
    //        {
    //            _dispatchers.Add(new DomainEventDispatcher<T>());
    //        }
    //    }
    //}
    /*
     *    internal static void Publish<T>(T value) where T:IDomainEvent
        {
            
            lists[typeof(DomainEventDispatcher<T>)] = value;
            

        }
        public void Subscrie<T>(Action<T> value) where T : IDomainEvent
        {
            lists[typeof(DomainEventDispatcher<T>)] = value;

        }
     */

}
