using GoalKeeper.Stats.Infrastructure.EventStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace GoalKeeper.Stats.EventStore
{
    public class EventStore : IEventStore
    {
        private readonly IDbConnection _connection;

        public EventStore(IDbConnection connection)
        {
            _connection = connection;
        }

        public Task<IEnumerable<int>> ReadEventsAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AppendEventAsync<TStream>(long streamId, object @event, long? expectedVersion = null)
        {
            string sql =
                "INSERT INTO [EventStore].[Events] (Data, Type, Version) " +
                "VALUES (@Data, @Type, @StreamId, @StreamType, @ExpectedVersion)";

            var result = _connection.ExecuteAsync(
                sql,
                new
                {
                    data = JsonConvert.SerializeObject(@event),
                    Type = @event.GetType().AssemblyQualifiedName,
                    StreamId = streamId,
                    StreamType = typeof(TStream).AssemblyQualifiedName,
                    ExpectedVersion = expectedVersion ?? 0
                },
                commandType: CommandType.Text);
            return result;
        }
    }
}
