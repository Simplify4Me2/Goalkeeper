using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.ValueObjects;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetUpcomingMatchdayQueryHandler : IRequestHandler<GetUpcomingMatchdayQuery, UpcomingMatchdayDTO>
    {
        private readonly IMatchRepository _repository;

        public GetUpcomingMatchdayQueryHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpcomingMatchdayDTO> Handle(GetUpcomingMatchdayQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetFixtures(request.Matchday, cancellationToken);

            var matchday = new UpcomingMatchday(request.Matchday, data.ToList());

            return matchday.MapOut();
        }
    }
}
