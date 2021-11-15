using FluentAssertions;
using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Services;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.Stats.Application.IO.UnitTests
{
    public class MatchServiceTests
    {
        [Fact]
        public async Task AllMatches_CorrectUrlGetsCalled()
        {
            // Arrange
            int matchday = 5;
            var expected = new Result<MatchdayDTO>(new());
            
            var client = CreateMockHttpClient(expected, $"/matchday/{matchday}");
            var service = new MatchService(client);

            // Act
            var response = await service.AllMatches(matchday, CancellationToken.None);

            // Assert
            response.Should().BeEquivalentTo(expected);
        }

        private static HttpClient CreateMockHttpClient<TResponse>(Result<TResponse> expectedResponse, string url)
        {
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When(url)
                .Respond("application/json",
                    JsonConvert.SerializeObject(expectedResponse));

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("http://localhost");
            return client;
        }
    }
}