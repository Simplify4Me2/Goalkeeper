using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetRankingQueryHandler : IRequestHandler<GetRankingQuery, RankingDTO>
    {
        private readonly IStatsRepository _statsRepository;
        private readonly IMatchRepository _matchRepository;

        public GetRankingQueryHandler(IStatsRepository statsRepository, IMatchRepository matchRepository)
        {
            _statsRepository = statsRepository;
            _matchRepository = matchRepository;
        }

        public async Task<RankingDTO> Handle(GetRankingQuery request, CancellationToken cancellationToken)
        {
            var teams = await _statsRepository.GetTeams(cancellationToken);
            var matches = await _matchRepository.Get(cancellationToken);

            League league = new League("Jupiler Pro League", teams.ToList(), matches.ToList());

            return league.MapOut();
        }
    }
}
