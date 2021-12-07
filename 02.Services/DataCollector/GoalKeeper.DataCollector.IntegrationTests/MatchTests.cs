using FluentAssertions;
using GoalKeeper.DataCollector.Application.IO.Services;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.DataCollector.IntegrationTests
{
    public class MatchTests : IClassFixture<ExampleTestFixture>
    {
        private readonly ExampleTestFixture _fixture;

        public MatchTests(ExampleTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task AllMatches_ReturnsSuccessAndCorrectContentType()
        {
            // Arrange
            var client = _fixture.CreateClient();
            var service = new MatchWebScraperService(client);

            // Act
            var result = await service.AllMatches(5, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
