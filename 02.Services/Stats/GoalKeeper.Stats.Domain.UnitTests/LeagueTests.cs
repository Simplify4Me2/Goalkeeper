using FluentAssertions;
using GoalKeeper.Stats.Domain.ValueObjects;
using GoalKeeper.Stats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static System.Formats.Asn1.AsnWriter;

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
                new Team(1, "Team 1", new Stadium(5, "Den Bruinen Dreef"), new List<Player>()),
                new Team(2, "Team 2", new Stadium(5, "Bosuilstadion"), new List<Player>()),
                new Team(3, "Team 3", new Stadium(5, "Regenboogstadion"), new List<Player>())
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
            var testTeam = new Team(1, "FC De Kampioenen", new Stadium(5, "Den Bruinen Dreef"), new List<Player>());
            var awayTeam1 = new Team(2, "Away Team 1", new Stadium(5, "Bosuilstadion"), new List<Player>());
            var teams = new List<Team> { testTeam, awayTeam1 };
            var matches = new List<Match>
            {
                new Match(1, testTeam, awayTeam1, new Score(3, 5), new DateTime(), 1)
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 0;
            league.Table.First(ranking => ranking.Team.Id == testTeam.Id).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_MatchWon_ReturnsThreePoints()
        {
            // Arrange
            var testTeam = new Team(1, "FC De Kampioenen", new Stadium(5, "Den Bruinen Dreef"), new List<Player>());
            var awayTeam1 = new Team(2, "Away Team 1", new Stadium(5, "Bosuilstadion"), new List<Player>());
            var teams = new List<Team> { testTeam, awayTeam1 };
            var matches = new List<Match>
            {
                new Match(1, testTeam, awayTeam1, new Score(5, 0), new DateTime(), 1)
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 3;
            league.Table.First(ranking => ranking.Team.Id == testTeam.Id).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_MatchDrawn_ReturnsOnePoints()
        {
            // Arrange
            var testTeam = new Team(1, "FC De Kampioenen", new Stadium(5, "Den Bruinen Dreef"), new List<Player>());
            var awayTeam1 = new Team(2, "Away Team 1", new Stadium(5, "Bosuilstadion"), new List<Player>());
            var teams = new List<Team> { testTeam, awayTeam1 };
            var matches = new List<Match>
            {
                new Match(1, testTeam, awayTeam1, new Score(0, 0), new DateTime(), 1)
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 1;
            league.Table.First(ranking => ranking.Team.Id == testTeam.Id).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_MatchDrawnAndMatchWon_ReturnsFourPoints()
        {
            // Arrange
            var testTeam = new Team(1, "FC De Kampioenen", new Stadium(5, "Den Bruinen Dreef"), new List<Player>());
            var otherTeam = new Team(2, "Away Team 1", new Stadium(5, "Bosuilstadion"), new List<Player>());
            var teams = new List<Team> { testTeam, otherTeam };
            var matches = new List<Match>
{
                new Match(1, testTeam, otherTeam, new Score(1, 1), new DateTime(), 1),
                new Match(2, otherTeam, testTeam, new Score(0, 1), new DateTime(), 1)
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 1 + 3;
            league.Table.First(ranking => ranking.Team.Id == testTeam.Id).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_ThreeMatches_WinDrawLoss_ReturnsFourPoints()
        {
            // Arrange
            var testTeam = new Team(1, "FC De Kampioenen", new Stadium(5, "Den Bruinen Dreef"), new List<Player>());
            var awayTeam1 = new Team(2, "Away Team 1", new Stadium(5, "Bosuilstadion"), new List<Player>());
            var awayTeam2 = new Team(3, "Away Team 2", new Stadium(5, "Regenboogstadion"), new List<Player>());
            var awayTeam3 = new Team(4, "Away Team 3", new Stadium(5, "Astridpark"), new List<Player>());
            var teams = new List<Team> { testTeam, awayTeam1, awayTeam2, awayTeam3 };
            var matches = new List<Match>
            {
                new Match(1, testTeam, awayTeam1, new Score(5, 0), new DateTime(), 1),
                new Match(2, awayTeam2, testTeam, new Score(2, 2), new DateTime(), 1),
                new Match(3, testTeam, awayTeam1, new Score(2, 3), new DateTime(), 1),
            };
            var league = new League("CBF", teams, matches);

            // Assert
            var expected = 3 + 1 + 0;
            league.Table.First(ranking => ranking.Team.Id == testTeam.Id).Points.Should().Be(expected);
        }

        [Fact]
        public void League_Table_OrdersDescendingByPoints()
        {
            // Arrange
            var team1 = new Team(1, "FC De Kampioenen", new Stadium(5, "Den Bruinen Dreef"), new List<Player>());
            var team2 = new Team(2, "Away Team 1", new Stadium(5, "Bosuilstadion"), new List<Player>());
            var team3 = new Team(3, "Away Team 2", new Stadium(5, "Regenboogstadion"), new List<Player>());
            var team4 = new Team(4, "Away Team 3", new Stadium(5, "Astridpark"), new List<Player>());
            var teams = new List<Team> { team1, team2, team3, team4 };
            var matches = new List<Match>
            {
                new Match(1, team1, team2, new Score(0, 5), new DateTime(), 1),
                new Match(2, team3, team4, new Score(1, 2), new DateTime(), 1),
                new Match(3, team3, team1, new Score(2, 3), new DateTime(), 2),
                new Match(4, team4, team2, new Score(2, 3), new DateTime(), 2),
                new Match(5, team1, team4, new Score(1, 0), new DateTime(), 3),
                new Match(6, team2, team3, new Score(2, 1), new DateTime(), 3),
            };
            var league = new League("CBF", teams, matches);

            // Assert
            league.Table.First().Team.Should().Be(team2);
            league.Table.Last().Team.Should().Be(team3);
        }
    }
}
