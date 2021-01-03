using EventStore.ClientAPI;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Core;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Infrastructure
{
    public class EventSourcingRepository : IEventSourcingRepository<Guid>
        //where T : IAggregate<Guid>
    {
        public EventSourcingRepository()
        {
        }

        //public Task<T> GetByIdAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task SaveAsync(T aggregate)
        //{
            

        //}

        public async Task SaveAsync(Guid aggregate)
        {
            var connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:2113"));
            await connection.ConnectAsync();

            const string streamName = "newstream";
            const string eventType = "event-type";
            const string data = "{ \"a\":\"2\"}";
            const string metadata = "{}";

            var eventPayload = new EventData(
                eventId: Guid.NewGuid(),
                type: eventType,
                isJson: true,
                data: Encoding.UTF8.GetBytes(data),
                metadata: Encoding.UTF8.GetBytes(metadata)
            );
            try
            {
                var result = await connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventPayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            //return result;
        }

        Task<Guid> IEventSourcingRepository<Guid>.GetByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
