using GoalKeeper.MApi.Application.IO.Queries.Fixtures;
using GoalKeeper.MApi.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.MApi.WebApi.UnitTests
{
    public class FixturesControllerTests
    {
        private readonly Mock<IMediator> _mediatr;
        private readonly FixturesController _controller;

        public FixturesControllerTests()
        {
            _mediatr = new Mock<IMediator>();
            _controller = new FixturesController(_mediatr.Object) { ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() } };
        }

        [Fact]
        public async Task GetFixtures_CallsQuery()
        {
            await _controller.GetFixtures();
            var query = new GetFixturesQuery();
            _mediatr.Verify(p => p.Send(It.IsAny<GetFixturesQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
