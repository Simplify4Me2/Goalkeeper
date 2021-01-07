using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Domain.Core
{
    public class Aggregate : IAggregate
    {
        //public const int NewAggregateVersion = -1;

        //private int _version = NewAggregateVersion;

        public long Id { get; protected set; }

        public int Version { get; protected set; }

        [JsonIgnore]
        private readonly List<object> uncommittedEvents = new List<object>();

        IEnumerable<object> IAggregate.DequeueUncommittedEvents()
        {
            var dequeuedEvents = uncommittedEvents.ToList();

            uncommittedEvents.Clear();

            return dequeuedEvents;
        }

        protected void Enqueue(object @event)
        {
            Version++;
            uncommittedEvents.Add(@event);
        }

        //protected void RaiseEvent<TEvent>(TEvent @event)
        //    where TEvent : DomainEventBase
        //{

        //}
    }
}
