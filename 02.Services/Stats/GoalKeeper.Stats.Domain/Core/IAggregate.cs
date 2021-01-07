using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Core
{
    public interface IAggregate
    {
        long Id { get; }

        int Version { get; }

        IEnumerable<object> DequeueUncommittedEvents();
    }
}
