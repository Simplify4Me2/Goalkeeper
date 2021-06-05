using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.WebApi.Controllers;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.Stats.WebApi.UnitTests
{
    public class TeamControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly TeamController controller;

        public TeamControllerTests()
        {
            _mediator = new Mock<IMediator>();
            controller = new TeamController(_mediator.Object);
        }

        [Fact]
        public async Task GetTeams_CallsQuery()
        {
            await controller.GetTeams();

            _mediator.Verify(p => p.Send(It.IsAny<GetTeamsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetTeamByName_CallsQuery()
        {
            string teamName = "FC De Kampioenen";
            await controller.GetTeamByName(teamName);

            _mediator.Verify(p => p.Send(It.IsAny<GetTeamByNameQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
