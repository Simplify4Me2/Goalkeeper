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
    public class FindTeamByNameQueryHandlerTests
    {
        private readonly Mock<IStatsRepository> _repository;
        private readonly Mock<IMatchRepository> _matchRepository;
        private readonly FindTeamByNameQueryHandler queryHandler;

        public FindTeamByNameQueryHandlerTests()
        {
            _repository = new Mock<IStatsRepository>();
            _matchRepository = new Mock<IMatchRepository>();
            _repository.Setup(x => x.GetTeamByName(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(new Domain.Team(12, "FC De Kampioenen", new Domain.Stadium(5, "Den Bruinen Dreef"), new List<Domain.Player>() { new Domain.Player(1, "Pico", "Coppens", new DateTime(), new DateTime(), 9, "ATT"), new Domain.Player(2, "Xavier", "Waterslaegers", new DateTime(), new DateTime(), 1, "GK") } ));
            queryHandler = new FindTeamByNameQueryHandler(_repository.Object, _matchRepository.Object);
        }

        [Fact]
        public async Task FindTeamByName_WithValidRequest_ReturnsData()
        {
            string teamName = "FC De Kampioenen";
            var response = await queryHandler.Handle(new FindTeamByNameQuery(teamName), CancellationToken.None);
            response.Should().NotBeNull();
            response.Id.Should().Be(12);
            response.Name.Should().Be(teamName);
            response.StadiumName.Should().Be("Den Bruinen Dreef");
            response.Players.Count().Should().Be(2);
            response.Form.Count().Should().Be(4);
            response.Form.Should().BeEquivalentTo(new[] { "-", "-", "-", "-" });
            _repository.Verify(x => x.GetTeamByName(teamName, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task FindTeamByName_WithInvalidRequest_ReturnsValidationException()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await queryHandler.Handle(new FindTeamByNameQuery(String.Empty), cancellationToken: CancellationToken.None);
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
