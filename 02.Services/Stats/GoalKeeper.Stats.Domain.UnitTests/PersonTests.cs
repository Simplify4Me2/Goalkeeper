using FluentAssertions;
using GoalKeeper.Stats.Domain.ValueObjects;
using System;
using Xunit;

namespace GoalKeeper.Stats.Domain.UnitTests
{
    public class PersonTests
    {
        [Fact]
        public void Person_Should_Return_Age()
        {
            // Arrange
            var person = new Person("Bobby", "Ewing", new DateTime(1985, 03, 18), new DateTime(2021, 07, 04));

            // Act
            var result = person.Age;

            // Assert
            result.Should().Be(36);
        }
    }
}
