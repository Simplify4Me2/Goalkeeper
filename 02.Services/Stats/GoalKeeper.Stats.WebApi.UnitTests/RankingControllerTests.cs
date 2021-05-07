using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.WebApi.Controllers;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.Stats.WebApi.UnitTests
{
    public class RankingControllerTests
    {
        private readonly Mock<IMediator> _mediatr;
        private readonly RankingController controller;

        public RankingControllerTests()
        {
            _mediatr = new Mock<IMediator>();
            controller = new RankingController(_mediatr.Object);
        }

        [Fact]
        public async Task GetRanking_CallsQuery()
        {
            await controller.GetRanking();
            _mediatr.Verify(p => p.Send(It.IsAny<GetRankingQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
