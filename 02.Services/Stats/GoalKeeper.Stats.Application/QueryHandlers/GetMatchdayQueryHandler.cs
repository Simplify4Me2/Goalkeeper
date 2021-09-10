using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Exceptions;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain;
using MediatR;
using System.Collections.Generic;
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
            IEnumerable<Match> data;
            if (request.Day == 0)
                data = await _repository.FindCurrentMatchday(cancellationToken);
            else
                data = await _repository.FindByMatchday(request.Day, cancellationToken);

            if (data.Count() == 0) throw new MatchdayNotFoundException($"No matches found for matchday {request.Day}.");

            var matchday = new Matchday(data.FirstOrDefault().Matchday, data.ToList());

            return matchday.MapOut();
        }
    }
}
