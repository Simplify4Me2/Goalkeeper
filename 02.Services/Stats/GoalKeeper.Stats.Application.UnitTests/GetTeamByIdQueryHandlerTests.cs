using FluentAssertions;
using FluentValidation;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Application.QueryHandlers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.Stats.Application.UnitTests
{
    public class GetTeamByIdQueryHandlerTests
    {
        private readonly Mock<IStatsRepository> _repository;
        private readonly GetTeamByIdQueryHandler queryHandler;

        public GetTeamByIdQueryHandlerTests()
        {
            _repository = new Mock<IStatsRepository>();
            _repository.Setup(x => x.GetTeamById(It.IsAny<long>(), CancellationToken.None))
                .ReturnsAsync(new Domain.ValueObjects.Team(12, "TeamName", new Domain.ValueObjects.Stadium(5, "Den Bruinen Dreef"), new List<Domain.ValueObjects.Player>() { new Domain.ValueObjects.Player(1, "Pico", "Coppens", new DateTime(), new DateTime(), 9, "ATT"), new Domain.ValueObjects.Player(2, "Xavier", "Waterslaegers", new DateTime(), new DateTime(), 1, "GK") } ));
            queryHandler = new GetTeamByIdQueryHandler(_repository.Object);
        }

        [Fact]
        public async Task GetTeamById_WithValidData_ReturnsData()
        {
            long teamId = 12;
            var response = await queryHandler.Handle(new GetTeamByIdQuery(teamId), CancellationToken.None);
            response.Should().NotBeNull();
            response.Id.Should().Be(12);
            response.Name.Should().Be("TeamName");
            response.StadiumName.Should().Be("Den Bruinen Dreef");
            response.Players.Count().Should().Be(2);
            _repository.Verify(x => x.GetTeamById(teamId, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task GetTeamById_WithInvalidData_ReturnsError()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await queryHandler.Handle(new GetTeamByIdQuery(0), cancellationToken: CancellationToken.None);
            });
        }

        //[Theory]
        //[InlineData(null)]
        //[InlineData(0)]
        //public async Task GetTeamById_WithInvalidData_ReturnsError(long teamId)
        //{
        //    await Assert.ThrowsAsync<ValidationException>(async () =>
        //    {
        //        await queryHandler.Handle(new GetTeamByIdQuery(teamId), cancellationToken: CancellationToken.None);
        //    });
        //}
    }
}
