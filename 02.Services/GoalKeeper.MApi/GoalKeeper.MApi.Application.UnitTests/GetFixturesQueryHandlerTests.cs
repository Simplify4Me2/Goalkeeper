using FluentAssertions;
using GoalKeeper.MApi.Application.IO.Queries.Fixtures;
using GoalKeeper.MApi.Application.Ports;
using GoalKeeper.MApi.Application.QueryHandlers.Fixtures;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.MApi.Application.UnitTests
{
    public class GetFixturesQueryHandlerTests
    {
        private readonly Mock<IGoalKeeperRepository> _repository;
        private readonly GetFixturesQueryHandler _queryHandler;

        public GetFixturesQueryHandlerTests()
        {
            _repository = new Mock<IGoalKeeperRepository>();
            _repository.Setup(x => x.GetFixtures(CancellationToken.None))
                .ReturnsAsync(new List<Domain.Models.Fixture>());
            _queryHandler = new GetFixturesQueryHandler(_repository.Object);
        }

        [Fact]
        public async Task GetFixtures_ReturnsData()
        {
            var response = await _queryHandler.Handle(new GetFixturesQuery(), cancellationToken: CancellationToken.None);
            response.Should().NotBeEmpty();
            response.Count.Should().Be(4);
            response.First().HomeTeam.Should().Be("FC De Kampioenen");
        }
    }
}
