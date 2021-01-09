using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, IEnumerable<TeamDTO>>
    {
        private readonly IStatsRepository _repository;

        public GetTeamsQueryHandler(IStatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TeamDTO>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetTeams(cancellationToken);
            return data.MapOut();
        }
    }
}
