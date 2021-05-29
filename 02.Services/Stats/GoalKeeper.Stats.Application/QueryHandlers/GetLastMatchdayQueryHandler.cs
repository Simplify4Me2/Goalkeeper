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
    public class GetLastMatchdayQueryHandler : IRequestHandler<GetLastMatchdayQuery, MatchdayDTO>
    {
        private readonly IStatsRepository _repository;

        public GetLastMatchdayQueryHandler(IStatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatchdayDTO> Handle(GetLastMatchdayQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetMatches(cancellationToken);

            var matchesFromLastMatchday = from match in data
                      where match.Matchday == data.Max(x => x.Matchday)
                      select match;

            var matchday = new Matchday
            {
                Day = matchesFromLastMatchday.Select(match => match.Matchday).First(),
                Matches = matchesFromLastMatchday
            };

            return matchday.MapOut();
        }
    }
}
