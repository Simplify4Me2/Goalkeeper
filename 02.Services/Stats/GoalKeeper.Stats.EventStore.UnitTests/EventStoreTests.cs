using Dapper;
using FluentAssertions;
using Moq;
using Moq.Dapper;
using System.Data;
using Xunit;

namespace GoalKeeper.Stats.EventStore.UnitTests
{
    public class EventStoreTests
    {
        public class User
        {
            public long Id { get; private set; }

            public string Name { get; private set; }

            public int Version { get; private set; }

            // For serialization
            private User() { }

            public User(long id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class UserCreated
        {
            public long UserId { get; }

            public string UserName { get; }

            public UserCreated(long userId, string userName)
            {
                UserId = userId;
                UserName = userName;
            }
        }

        private readonly Mock<IDbConnection> _connection;

        public MyEventStore eventStore { get; }

        public EventStoreTests()
        {
            _connection = new Mock<IDbConnection>();
            //_connection.SetupDapper(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), commandType: CommandType.Text)).ReturnsAsync(1);
            //_connection.SetupDapperAsync(x => x.ExecuteAsync<int>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), null, CommandType.Text)).ReturnsAsync(1);
            //_connection.SetupDapperAsync(x => x.QueryAsync<int>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), null, CommandType.Text)).ReturnsAsync(1);
            eventStore = new MyEventStore(_connection.Object);
        }

        //[Fact]
        //public void AggregateStream_ShouldReturnStream()
        //{
        //    // Arrange
        //    long streamId = 5;
        //    var @event = new UserCreated(streamId, "John Doe");
        //    eventStore.AppendEventAsync<User>(streamId, @event);

        //    // Act
        //    var aggregate = eventStore.AggregateStream<User>(streamId);

        //    // Assert
        //    aggregate.Version.Should().BeGreaterThan(1);
        //}

    }
}
