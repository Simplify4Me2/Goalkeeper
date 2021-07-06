using FluentAssertions;
using GoalKeeper.Common.Domain;
using GoalKeeper.Stats.Domain.Primitives;
using Moq;
using System;
using Xunit;

namespace GoalKeeper.Stats.Domain.UnitTests
{
    public class PersonTests
    {
        private Mock<IDateTimeProvider> _dateTimeProvider;

        public PersonTests()
        {
            _dateTimeProvider = new Mock<IDateTimeProvider>();
        }

        [Fact]
        public void Person_Should_Return_Age()
        {
            // Arrange
            _dateTimeProvider.Setup(x => x.Today).Returns(new DateTime(2021, 07, 04));
            var person = new Person("Bobby", "Ewing", new DateTime(1985, 03, 18), _dateTimeProvider.Object);

            // Act
            var result = person.Age;

            // Assert
            result.Should().Be(36);
        }
    }
}
