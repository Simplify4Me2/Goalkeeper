using FluentAssertions;
using GoalKeeper.Stats.Application.CommandHandlers;
using GoalKeeper.Stats.Application.IO.Commands;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.Stats.Application.UnitTests
{
    public class MatchPlayedCommandHandlerTests
    {
        private readonly Mock<IStatsRepository> _statsRepository;
        private readonly Mock<IMatchRepository> _matchRepository;

        private readonly MatchPlayedCommandHandler commandHandler;

        public MatchPlayedCommandHandlerTests()
        {
            _statsRepository = new Mock<IStatsRepository>();
            _matchRepository = new Mock<IMatchRepository>();

            commandHandler = new MatchPlayedCommandHandler(_statsRepository.Object, _matchRepository.Object);
        }

        [Fact]
        public async Task MatchPlayed_CallsSave_WithIdZero()
        {
            // Arrange
            var homeTeam = new Team(1, "HomeTeam", SomePlayers());
            var awayTeam = new Team(2, "AwayTeam", SomePlayers());
            var command = new MatchPlayedCommand(homeTeam.Name, 0, awayTeam.Name, 0, DateTime.Today, 0);
            _matchRepository.Setup(x => x.Save(It.IsAny<Domain.Entities.Match>(), CancellationToken.None)).ReturnsAsync(true);

            // Act
            var response = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeTrue();
            _matchRepository.Verify(x => x.Save(It.Is<Domain.Entities.Match>(match => match.Id.Equals(0)), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task MatchPlayed_CallsSave_WithHomeTeam()
        {
            // Arrange
            var homeTeam = new Team(1, "HomeTeam", SomePlayers());
            var awayTeam = new Team(2, "AwayTeam", SomePlayers());
            var command = new MatchPlayedCommand(homeTeam.Name, 0, awayTeam.Name, 0, DateTime.Today, 0);
            _statsRepository.Setup(x => x.GetTeamByName(homeTeam.Name, CancellationToken.None)).ReturnsAsync(homeTeam);
            _matchRepository.Setup(x => x.Save(It.IsAny<Domain.Entities.Match>(), CancellationToken.None)).ReturnsAsync(true);

            // Act
            var response = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeTrue();
            _matchRepository.Verify(x => x.Save(It.Is<Domain.Entities.Match>(match => match.HomeTeam.Equals(homeTeam)), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task MatchPlayed_CallsSave_WithHomeTeamScore()
        {
            // Arrange
            var homeTeam = new Team(1, "HomeTeam", SomePlayers());
            var awayTeam = new Team(2, "AwayTeam", SomePlayers());
            var homeTeamScore = 3;
            var command = new MatchPlayedCommand(homeTeam.Name, homeTeamScore, awayTeam.Name, 0, DateTime.Today, 0);
            _matchRepository.Setup(x => x.Save(It.IsAny<Domain.Entities.Match>(), CancellationToken.None)).ReturnsAsync(true);

            // Act
            var response = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeTrue();
            _matchRepository.Verify(x => x.Save(It.Is<Domain.Entities.Match>(match => match.HomeTeamScore.Equals(homeTeamScore)), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task MatchPlayed_CallsSave_WithAwayTeam()
        {
            // Arrange
            var homeTeam = new Team(1, "HomeTeam", SomePlayers());
            var awayTeam = new Team(2, "AwayTeam", SomePlayers());
            var command = new MatchPlayedCommand(homeTeam.Name, 0, awayTeam.Name, 0, DateTime.Today, 0);
            _statsRepository.Setup(x => x.GetTeamByName(awayTeam.Name, CancellationToken.None)).ReturnsAsync(awayTeam);
            _matchRepository.Setup(x => x.Save(It.IsAny<Domain.Entities.Match>(), CancellationToken.None)).ReturnsAsync(true);

            // Act
            var response = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeTrue();
            _matchRepository.Verify(x => x.Save(It.Is<Domain.Entities.Match>(match => match.AwayTeam.Equals(awayTeam)), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task MatchPlayed_CallsSave_WithAwayTeamScore()
        {
            // Arrange
            var homeTeam = new Team(1, "HomeTeam", SomePlayers());
            var awayTeam = new Team(2, "AwayTeam", SomePlayers());
            var awayTeamScore = 3;
            var command = new MatchPlayedCommand(homeTeam.Name, 0, awayTeam.Name, awayTeamScore, DateTime.Today, 0);
            _matchRepository.Setup(x => x.Save(It.IsAny<Domain.Entities.Match>(), CancellationToken.None)).ReturnsAsync(true);

            // Act
            var response = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeTrue();
            _matchRepository.Verify(x => x.Save(It.Is<Domain.Entities.Match>(match => match.AwayTeamScore.Equals(awayTeamScore)), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task MatchPlayed_CallsSave_WithMatchDate()
        {
            // Arrange
            var homeTeam = new Team(1, "HomeTeam", SomePlayers());
            var awayTeam = new Team(2, "AwayTeam", SomePlayers());
            var matchDate = new DateTime(2021, 08, 01);
            var command = new MatchPlayedCommand(homeTeam.Name, 0, awayTeam.Name, 0, matchDate, 0);
            _matchRepository.Setup(x => x.Save(It.IsAny<Domain.Entities.Match>(), CancellationToken.None)).ReturnsAsync(true);

            // Act
            var response = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeTrue();
            _matchRepository.Verify(x => x.Save(It.Is<Domain.Entities.Match>(match => match.Date.Equals(matchDate)), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task MatchPlayed_CallsSave_WithMatchDay()
        {
            // Arrange
            var homeTeam = new Team(1, "HomeTeam", SomePlayers());
            var awayTeam = new Team(2, "AwayTeam", SomePlayers());
            var matchDay = 3;
            var command = new MatchPlayedCommand(homeTeam.Name, 0, awayTeam.Name, 0, DateTime.Today, matchDay);
            _matchRepository.Setup(x => x.Save(It.IsAny<Domain.Entities.Match>(), CancellationToken.None)).ReturnsAsync(true);

            // Act
            var response = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().BeTrue();
            _matchRepository.Verify(x => x.Save(It.Is<Domain.Entities.Match>(match => match.Matchday.Equals(matchDay)), CancellationToken.None), Times.Once);
        }

        private List<Player> SomePlayers()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player(1, "Pico", "Coppens", new DateTime(2000, 01, 01), DateTime.Today, 9, "ATT"));
            players.Add(new Player(1, "Xavier", "Waterslaegers", new DateTime(2000, 01, 01), DateTime.Today, 1, "GK"));
            players.Add(new Player(1, "Lionel", "Messi", new DateTime(2000, 01, 01), DateTime.Today, 11, "ATT"));
            return players;
        }
    }
}
