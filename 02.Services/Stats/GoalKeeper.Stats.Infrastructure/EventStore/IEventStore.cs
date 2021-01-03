using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Infrastructure.EventStore
{
    public interface IEventStore
    {
        Task<IEnumerable<int>> ReadEventsAsync(long id);

        Task<int> AppendEventAsync<TStream>(long streamId, object @event, long? expectedVersion = null);
    }
}
