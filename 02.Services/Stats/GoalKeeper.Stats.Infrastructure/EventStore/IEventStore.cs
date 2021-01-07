using GoalKeeper.Stats.Domain.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Infrastructure.EventStore
{
    public interface IEventStore
    {
        bool Store<TStream>(TStream aggregate) where TStream : IAggregate;
        
        Task<int> AppendEventAsync<TStream>(long streamId, object @event, long? expectedVersion = null);

        T AggregateStream<T>(long streamId, long? atStreamVersion = null, DateTime? atTimeStamp = null);
        
        IEnumerable<Event> ReadEvents(long streamId, long? atStreamVersion = null, DateTime? atTimeStamp = null);

        StreamState ReadStreamState(long streamId);
    }
}
