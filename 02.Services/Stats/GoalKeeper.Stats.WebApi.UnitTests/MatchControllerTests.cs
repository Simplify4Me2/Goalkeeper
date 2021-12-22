using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.WebApi.Controllers;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.Stats.WebApi.UnitTests
{
    public class MatchControllerTests
    {
        private readonly Mock<IMediator> _mediatr;
        private readonly MatchController controller;

        public MatchControllerTests()
        {
            _mediatr = new Mock<IMediator>();
            controller = new MatchController(_mediatr.Object);
        }

        [Fact]
        public async Task GetMatchday_CallsQuery()
        {
            int matchday = 5;
            await controller.GetMatchday(matchday);
            _mediatr.Verify(p => p.Send(It.IsAny<GetMatchdayQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
