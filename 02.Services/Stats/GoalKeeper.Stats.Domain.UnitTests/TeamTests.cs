using FluentAssertions;
using Xunit;

namespace GoalKeeper.Stats.Domain.UnitTests
{
    public class TeamTests
    {
        [Fact]
        public void Team_FormToString_Should_Return_FourStrings()
        {
            // Arrange
            var team = new Team(12, "FC De Kampioenen", null, null);
            List<Match> matches = new List<Match> { };

            // Act
            var result = team.FormToString(matches);

            // Assert
            result.Count().Should().Be(4);
        }

        [Fact]
        public void Team_FormToString_Should_Return_WForWin()
        {
            // Arrange
            var team = new Team(12, "FC De Kampioenen", null, null);
            var otherTeam = new Team(34, "FC Nelly Boys", null, null); ;
            List<Match> matches = new List<Match> {
            new Match(1, team, otherTeam, new Score(1,0), new DateTime(2021, 01, 01), 4),
            new Match(2, otherTeam, team, new Score(0,2), new DateTime(2021, 01, 08), 5),
            new Match(3, team, otherTeam, new Score(2,1), new DateTime(2021, 01, 15), 6),
            new Match(4, otherTeam, team, new Score(1,3), new DateTime(2021, 01, 22), 7),
            };

            // Act
            var result = team.FormToString(matches);

            // Assert
            string[] exptected = new string[] { "W", "W", "W", "W" };
            result.Should().BeEquivalentTo(exptected);
        }

        [Fact]
        public void Team_FormToString_Should_Return_DForDraw()
        {
            // Arrange
            var team = new Team(12, "FC De Kampioenen", null, null);
            var otherTeam = new Team(34, "FC Nelly Boys", null, null); ;
            List<Match> matches = new List<Match> {
            new Match(1, team, otherTeam, new Score(1,1), new DateTime(2021, 01, 01), 4),
            new Match(2, otherTeam, team, new Score(2,2), new DateTime(2021, 01, 08), 5),
            new Match(3, team, otherTeam, new Score(2,2), new DateTime(2021, 01, 15), 6),
            new Match(4, otherTeam, team, new Score(3,3), new DateTime(2021, 01, 22), 7),
            };

            // Act
            var result = team.FormToString(matches);

            // Assert
            string[] exptected = new string[] { "D", "D", "D", "D" };
            result.Should().BeEquivalentTo(exptected);
        }

        [Fact]
        public void Team_FormToString_Should_Return_LForLoss()
        {
            // Arrange
            var team = new Team(12, "FC De Kampioenen", null, null);
            var otherTeam = new Team(34, "FC Nelly Boys", null, null); ;
            List<Match> matches = new List<Match> {
            new Match(1, team, otherTeam, new Score(0,1), new DateTime(2021, 01, 01), 4),
            new Match(2, otherTeam, team, new Score(2,1), new DateTime(2021, 01, 08), 5),
            new Match(3, team, otherTeam, new Score(0,2), new DateTime(2021, 01, 15), 6),
            new Match(4, otherTeam, team, new Score(4,3), new DateTime(2021, 01, 22), 7),
            };

            // Act
            var result = team.FormToString(matches);

            // Assert
            string[] exptected = new string[] { "L", "L", "L", "L" };
            result.Should().BeEquivalentTo(exptected);
        }

        [Fact]
        public void Team_FormToString_Should_Return_DashForNotPlayed()
        {
            // Arrange
            var team = new Team(12, "FC De Kampioenen", null, null);
            var otherTeam = new Team(34, "FC Nelly Boys", null, null); ;
            List<Match> matches = new List<Match> {
            new Match(2, otherTeam, team, new Score(2,1), new DateTime(2021, 01, 08), 5),
            new Match(3, team, otherTeam, new Score(3,2), new DateTime(2021, 01, 15), 6),
            new Match(4, otherTeam, team, new Score(3,3), new DateTime(2021, 01, 22), 7),
            };

            // Act
            var result = team.FormToString(matches);

            // Assert
            string[] exptected = new string[] { "-", "L", "W", "D" };
            result.Should().BeEquivalentTo(exptected);
        }

        [Fact]
        public void Team_FormToString_Should_Return_CorrectCombination()
        {
            // Arrange
            var team = new Team(12, "FC De Kampioenen", null, null);
            var otherTeam = new Team(34, "FC Nelly Boys", null, null); ;
            List<Match> matches = new List<Match> {
            new Match(1, otherTeam, team, new Score(2,1), new DateTime(2021, 01, 08), 5),
            };

            // Act
            var result = team.FormToString(matches);

            // Assert
            string[] exptected = new string[] { "-", "-", "-", "L" };
            result.Should().BeEquivalentTo(exptected);
        }
    }
}
