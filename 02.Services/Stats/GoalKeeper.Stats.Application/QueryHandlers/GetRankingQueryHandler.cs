using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using MediatR;
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
            var data = await _repository.GetRanking(cancellationToken);
            return data.MapOut();
        }
    }
}
