using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wps.SharedKernel
{
    public class DomainEventDispatcher<T> where T : IDomainEvent
    {
        public List<Action<T>> Actions { get; } = new();
        public void Subscrie(Action<T> action) // Give me a Method that have  a Input of T and void and in publush I pass input to you by publisher
        {
            if (!Actions.Exists(a => a.Method == action.Method))
                Actions.Add(action);
        }
        public void Publish(T arg)
        {
            foreach (Action<T> action in Actions)
            {
                action.Invoke(arg);
            }
        }


    }
}
