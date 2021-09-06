using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetMatchdayQueryHandler : IRequestHandler<GetMatchdayQuery, MatchdayDTO>
    {
        private readonly IMatchRepository _repository;

        public GetMatchdayQueryHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatchdayDTO> Handle(GetMatchdayQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.FindByMatchday(request.Day, cancellationToken);

            var matchday = new Matchday(request.Day, data.ToList());

            return matchday.MapOut();
        }
    }
}
