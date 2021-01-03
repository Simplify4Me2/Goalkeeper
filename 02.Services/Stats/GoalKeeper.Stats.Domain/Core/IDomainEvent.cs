using System;

namespace GoalKeeper.Stats.Domain.Core
{
    public interface IDomainEvent
    {
        Guid EventId { get; }

        long AggregateId { get; }

        long AggregateVersion { get; }
    }
}
