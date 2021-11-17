using FluentAssertions;
using GoalKeeper.Stats.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Api = GoalKeeper.Stats.WebApi;

namespace GoalKeeper.Stats.IntegrationTests
{
    public class MatchTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Api.Startup> _factory;

        public MatchTests(WebApplicationFactory<Api.Startup> factory)
        {
            //_client = fixture.CreateClient();
            //_client.BaseAddress(new Uri("https://localhost"));

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
    }
}
