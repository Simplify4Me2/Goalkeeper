using GoalKeeper.Stats.Application.CommandHandlers;
using GoalKeeper.Stats.Application.Ports;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GoalKeeper.Stats.Application.UnitTests
{
    public class MatchPlayedCommandHandlerTests
    {
        private readonly Mock<IStatsRepository> _statsRepository;
        private readonly Mock<IMatchRepository> _matchRepository;

        private readonly MatchPlayedCommandHandler commandHandler;

        public MatchPlayedCommandHandlerTests()
        {
            _statsRepository = new Mock<IStatsRepository>();
            _matchRepository = new Mock<IMatchRepository>();

            commandHandler = new MatchPlayedCommandHandler(_statsRepository.Object, _matchRepository.Object);
        }

        [Fact]
        public void MatchPlayed_HomeTeamNotFound_Returns_TODO()
        {

        }
    }
}
