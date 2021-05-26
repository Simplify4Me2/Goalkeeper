using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetMatchesFromLastMatchdayQueryHandler : IRequestHandler<GetMatchesFromLastMatchdayQuery, IEnumerable<MatchDTO>>
    {
        private readonly IStatsRepository _repository;

        public GetMatchesFromLastMatchdayQueryHandler(IStatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MatchDTO>> Handle(GetMatchesFromLastMatchdayQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetMatches(cancellationToken);

            var matchesFromLastMatchday = from match in data
                      where match.Matchday == data.Max(x => x.Matchday)
                      select match;

            return matchesFromLastMatchday.MapOut();
        }
    }
}
