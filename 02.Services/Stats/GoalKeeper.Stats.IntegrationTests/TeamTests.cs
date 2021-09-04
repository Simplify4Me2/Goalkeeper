using FluentAssertions;
using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Services;
using GoalKeeper.Stats.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.Stats.IntegrationTests
{
    // https://timdeschryver.dev/blog/how-to-test-your-csharp-web-api
    public class TeamTests : IClassFixture<WebApplicationFactory<TeamController>>
    {
        //private readonly TeamService _service;
        readonly HttpClient _client;

        public TeamTests(WebApplicationFactory<TeamController> fixture)
        {
            _client = fixture.CreateClient();
            //var clientFactory = new Mock<IHttpClientFactory>();
            //clientFactory.Setup(x => x.CreateClient("auToHttpClient"))
            //             .Returns(() => TokenHelper.GetAuthenticatedClient());

            //var serviceConfiguration = Configuration.GetApplicationConfiguration();

            //_service = new TeamService()
        }

        [Fact]
        public async Task Test1()
        {
            //await _service.GetTeam("Test", CancellationToken.None);

            var response = await _client.GetAsync("api/team");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var teams = JsonConvert.DeserializeObject<Result<IEnumerable<TeamDTO>>>(await response.Content.ReadAsStringAsync());
            teams.Data.Should().HaveCount(18);
        }

        [Fact]
        public async Task Test2()
        {
            //await _service.GetTeam("Test", CancellationToken.None);

            var response = await _client.GetAsync("api/team");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var teams = JsonConvert.DeserializeObject<Result<IEnumerable<TeamDTO>>>(await response.Content.ReadAsStringAsync());
            teams.Data.Should().HaveCount(18);
        }
    }
}
