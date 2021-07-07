using FluentAssertions;
using GoalKeeper.Stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GoalKeeper.Stats.Domain.UnitTests
{
    public class LeagueTests
    {
        [Fact]
        public void League_Table_ReturnsRankingForEachTeamInCompetition()
        {
            // Arrange
            var teams = new List<Team>
            {
                new Team(1, "Team 1", new List<Player>()),
                new Team(2, "Team 2", new List<Player>()),
                new Team(3, "Team 3", new List<Player>())
            };
            var matches = new List<Match>();
            var league = new League("CBF", teams, matches);

            // Assert
            league.Table.Count.Should().Be(teams.Count);
        }


        [Fact]
        public void League_Table_MatchLost_ReturnsZeroPoints()
        {
            // Arrange
            var testTeam = new Team(1, "FC De Kampioenen", new List<Player>());
            var awayTeam1 = new Team(2, "Away Team 1", new List<Player>());
            var teams = new List<Team> { testTeam, awayTeam1 };
            var matches = new List<Match>
            {
                new Match(1, testTeam, 3, awayTeam1, 5, new DateTime(), 1)
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 0;
            league.Table.First(ranking => ranking.Team == testTeam).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_MatchWon_ReturnsThreePoints()
        {
            // Arrange
            var testTeam = new Team(1, "FC De Kampioenen", new List<Player>());
            var awayTeam1 = new Team(2, "Away Team 1", new List<Player>());
            var teams = new List<Team> { testTeam, awayTeam1 };
            var matches = new List<Match>
            {
                new Match(1, testTeam, 5, awayTeam1, 0, new DateTime(), 1)
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 3;
            league.Table.First(ranking => ranking.Team == testTeam).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_MatchDrawn_ReturnsOnePoints()
        {
            // Arrange
            var testTeam = new Team(1, "FC De Kampioenen", new List<Player>());
            var awayTeam1 = new Team(2, "Away Team 1", new List<Player>());
            var teams = new List<Team> { testTeam, awayTeam1 };
            var matches = new List<Match>
            {
                new Match(1, testTeam, 0, awayTeam1, 0, new DateTime(), 1)
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 1;
            league.Table.First(ranking => ranking.Team == testTeam).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_ThreeMatches_WinDrawLoss_ReturnsFourPoints()
        {
            // Arrange
            var testTeam = new Team(1, "FC De Kampioenen", new List<Player>());
            var awayTeam1 = new Team(2, "Away Team 1", new List<Player>());
            var awayTeam2 = new Team(3, "Away Team 2", new List<Player>());
            var awayTeam3 = new Team(4, "Away Team 3", new List<Player>());
            var teams = new List<Team> { testTeam, awayTeam1, awayTeam2, awayTeam3 };
            var matches = new List<Match>
            {
                new Match(1, testTeam, 5, awayTeam1, 0, new DateTime(), 1),
                new Match(2, awayTeam2, 2, testTeam, 2, new DateTime(), 1),
                new Match(3, testTeam, 2, awayTeam1, 3, new DateTime(), 1),
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 3 + 1 + 0;
            league.Table.First(ranking => ranking.Team == testTeam).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_OrdersDescendingByPoints()
        {
            // Arrange
            var team1 = new Team(1, "FC De Kampioenen", new List<Player>());
            var team2 = new Team(2, "Away Team 1", new List<Player>());
            var team3 = new Team(3, "Away Team 2", new List<Player>());
            var team4 = new Team(4, "Away Team 3", new List<Player>());
            var teams = new List<Team> { team1, team2, team3, team4 };
            var matches = new List<Match>
            {
                new Match(1, team1, 0, team2, 5, new DateTime(), 1),
                new Match(2, team3, 1, team4, 2, new DateTime(), 1),
                new Match(3, team3, 2, team1, 3, new DateTime(), 2),
                new Match(4, team4, 2, team2, 3, new DateTime(), 2),
                new Match(5, team1, 1, team4, 0, new DateTime(), 3),
                new Match(6, team2, 2, team3, 1, new DateTime(), 3),
            };
            var league = new League("CBF", teams, matches);

            // Assert
            league.Table.First().Team.Should().Be(team2);
            league.Table.Last().Team.Should().Be(team3);
        }
    }
}
