using System;

namespace GoalKeeper.Stats.Infrastructure.EventStore
{
    public class StreamState
    {
        public long Id { get; }

        public Type Type { get; }

        public int Version { get; }

        public StreamState(long id, Type type, int version)
        {
            Id = id;
            Type = type;
            Version = version;
        }
    }
}
