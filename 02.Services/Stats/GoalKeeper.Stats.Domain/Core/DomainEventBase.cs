using System;

namespace GoalKeeper.Stats.Domain.Core
{
    public abstract class DomainEventBase : IDomainEvent
    {
        public Guid EventId { get; private set; }

        public long AggregateId { get; private set; }

        public long AggregateVersion { get; private set; }
    }
}
