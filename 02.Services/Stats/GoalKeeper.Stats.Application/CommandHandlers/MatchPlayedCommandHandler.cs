using GoalKeeper.Stats.Application.IO.Commands;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.CommandHandlers
{
    public class MatchPlayedCommandHandler : IRequestHandler<MatchPlayedCommand, bool>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IStatsRepository _statsRepository;

        public MatchPlayedCommandHandler(IStatsRepository statsRepository, IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
            _statsRepository = statsRepository;
        }

        public async Task<bool> Handle(MatchPlayedCommand request, CancellationToken cancellationToken)
        {
            var homeTeam = await _statsRepository.GetTeamByName(request.HomeTeamName, cancellationToken);
            var awayTeam = await _statsRepository.GetTeamByName(request.AwayTeamName, cancellationToken);

            var match = new Match(0, homeTeam, request.HomeTeamScore, awayTeam, request.AwayTeamScore, request.Date, request.Matchday);

            return await _matchRepository.Save(match, cancellationToken);
        }
    }
}
