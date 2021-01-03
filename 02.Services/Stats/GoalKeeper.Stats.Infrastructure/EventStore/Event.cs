using System;

namespace GoalKeeper.Stats.Infrastructure.EventStore
{
    public class Event
    {
        public long Id { get; set; }

        public object Data { get; set; }

        public long StreamId { get; set; }

        public Type Type { get; set; }

        public int Version { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
