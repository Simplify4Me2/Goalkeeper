using GoalKeeper.Stats.Application.IO.Services;
using Moq;
using System.Net.Http;
using Xunit;

namespace GoalKeeper.Stats.IntegrationTests
{
    public class TeamTests
    {
        private readonly TeamService _service;

        public TeamTests()
{
            //var clientFactory = new Mock<IHttpClientFactory>();
            //clientFactory.Setup(x => x.CreateClient("auToHttpClient"))
            //             .Returns(() => TokenHelper.GetAuthenticatedClient());

            //var serviceConfiguration = Configuration.GetApplicationConfiguration();

            //_service = new TeamService()
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
