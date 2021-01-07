using Dapper;
using GoalKeeper.Stats.Domain.Core;
using GoalKeeper.Stats.EventStore.Utils;
using GoalKeeper.Stats.Infrastructure.EventStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.EventStore
{
    public class MyEventStore : IEventStore
    {
        private readonly IDbConnection _connection;

        public MyEventStore(IDbConnection connection)
        {
            _connection = connection;
        }

        public T AggregateStream<T>(long streamId, long? atStreamVersion = null, DateTime? atTimeStamp = null)
        {
            var aggregate = (T)Activator.CreateInstance(typeof(T), true);

            var events = ReadEvents(streamId);
            var version = 0;

            foreach (var @event in events)
            {
                aggregate.InvokeIfExists("Apply", @event);
                aggregate.SetIfExists("Version", ++version);
            }

            return aggregate;
        }

        public Task<int> AppendEventAsync<TStream>(long streamId, object @event, long? expectedVersion = null)
        {
            // TODO: refactor to stored procedure (migration + execute SP with Dapper)
            string sql =
                "DECLARE " +
                "   @streamVersion INT" +
                "BEGIN" +
                    "-- get stream version" +
                    "SET @streamVersion = (SELECT[Version] FROM[EventStore].[Streams] AS stream WHERE stream.Id = @StreamId)" +

                    "-- if stream doesn't exist - create new one with version 0" +
                    "IF @streamVersion IS NULL" +
                    "BEGIN" +
                        "SET @streamVersion = 0" +
                        "INSERT INTO[EventStore].[Streams] ([Type], [Version], [CreatedUtc], [CreatedBy])" +
                        "VALUES(@StreamType, @streamVersion, GETDATE(), 'TODO');" +
                    "END" +

                    "--check optimistic concurrency" +
                    "IF @ExpectedVersion IS NOT NULL AND @streamVersion != @ExpectedVersion" +
                        "RETURN 0;" +

                    "--increment event_version" +
                    "SET @streamVersion = @streamVersion + 1;" +

                    "--append event" +
                    "INSERT INTO[EventStore].[Events] ([Data], [StreamId], [Type], [CreatedUtc], [CreatedBy])" +
                    "VALUES(@Data, @StreamId, @Type, GETDATE(), 'TODO')" +

                    "-- update stream version" +
                    "UPDATE[EventStore].[Streams]" +
                    "SET[Version] = @streamVersion" +
                    "WHERE stream.Id = @StreamId" +

                    "RETURN 1;" +
                "END;";

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

        public IEnumerable<Event> ReadEvents(long streamId, long? atStreamVersion = null, DateTime? atTimeStamp = null)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@streamId", streamId, DbType.Int64);
            parameters.Add("@streamVersion", atStreamVersion ?? 0, DbType.Int64);
            parameters.Add("@timeStamp", atTimeStamp ?? DateTime.Now, DbType.DateTime2);

            string sql = $"SELECT [Id], [Data], [StreamId], [Type], [Version], [CreatedUtc] " +
                $"FROM [EventStore].[Events] " +
                $"WHERE [Events].[StreamId] = @streamId " +
                    $"AND (@streamVersion IS NULL OR [Version] <= @streamVersion)" +
                    $"AND (@timeStamp IS NULL OR [CreatedUtc] <= @timeStamp)" +
                $"ORDER BY [Version]";
            try
            {
                var result = _connection.Query<Event>(sql, parameters);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return new Event[0];
        }

        public StreamState ReadStreamState(long streamId)
        {
            string sql = $"SELECT [Id], [Type], [Version] FROM [EventStore].[Streams] WHERE [Streams].[Id] = {streamId}";
            var result = _connection.QuerySingleOrDefault<StreamState>(sql);
            return result;
        }

        public bool Store<TStream>(TStream aggregate) where TStream : IAggregate
        {
            var events = aggregate.DequeueUncommittedEvents();
            var initialVersion = aggregate.Version - events.Count();

            foreach (var @event in events)
            {
                AppendEventAsync<TStream>(aggregate.Id, @event, initialVersion++);
            }

            return true;
        }
    }
}
