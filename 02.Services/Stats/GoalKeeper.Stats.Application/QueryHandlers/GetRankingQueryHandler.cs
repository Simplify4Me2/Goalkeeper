using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetRankingQueryHandler : IRequestHandler<GetRankingQuery, RankingDTO>
    {
        private readonly IStatsRepository _repository;

        public GetRankingQueryHandler(IStatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<RankingDTO> Handle(GetRankingQuery request, CancellationToken cancellationToken)
        {
            var matches = await _repository.GetMatches(cancellationToken);
            var teams = await _repository.GetTeams(cancellationToken);

            League league = new League("Jupiler Pro League", teams.ToList(), matches.ToList());

            return league.MapOut();
        }
    }
}
