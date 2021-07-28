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
    public class GetMatchdayQueryHandler : IRequestHandler<GetMatchdayQuery, MatchdayDTO>
    {
        private readonly IMatchRepository _repository;

        public GetMatchdayQueryHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatchdayDTO> Handle(GetMatchdayQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.Get(cancellationToken);

            var matchesFromMatchday = from match in data
                      where match.Matchday == request.Day
                      select match;

            var matchday = new Matchday(matchesFromMatchday.Select(match => match.Matchday).First(), matchesFromMatchday);

            return matchday.MapOut();
        }
    }
}
