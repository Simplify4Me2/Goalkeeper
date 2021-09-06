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
    public class GetLastMatchdayQueryHandler : IRequestHandler<GetLastMatchdayQuery, MatchdayDTO>
    {
        private readonly IMatchRepository _repository;

        public GetLastMatchdayQueryHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatchdayDTO> Handle(GetLastMatchdayQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.Get(cancellationToken);

            var matchesFromLastMatchday = (from match in data
                      where match.Matchday == data.Max(x => x.Matchday)
                      select match).ToList();

            var matchday = new Matchday(matchesFromLastMatchday.Select(match => match.Matchday).First(), matchesFromLastMatchday);

            return matchday.MapOut();
        }
    }
}
