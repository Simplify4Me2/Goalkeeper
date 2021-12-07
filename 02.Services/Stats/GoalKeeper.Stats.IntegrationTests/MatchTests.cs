using FluentAssertions;
using GoalKeeper.Stats.Application.IO.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Api = GoalKeeper.Stats.WebApi;

namespace GoalKeeper.Stats.IntegrationTests
{
    public class MatchTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;

        public MatchTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetMatchday_retrieves_SingleMatchday()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/match/matchday/5");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task AllMatches_ReturnsSuccesAndCorrectContentType()
        {
            var client = _factory.CreateClient();
            var service = new MatchService(client);

            var result = await service.AllMatches(5, CancellationToken.None);

            result.Should().NotBeNull();
        }
    }
}
