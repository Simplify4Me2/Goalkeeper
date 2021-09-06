using FluentAssertions;
using Xunit;

namespace GoalKeeper.Stats.Domain.UnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_Should_Return_Age()
        {
            // Arrange
            var player = new Player(1, "Bobby", "Ewing", new DateTime(1985, 03, 18), new DateTime(2021, 07, 04), 15, "ATT");

            // Act
            var result = player.Age;

            // Assert
            result.Should().Be(36);
        }
    }
}
