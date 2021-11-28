using GoalKeeper.DataCollector.Application.IO.DTOs;
using GoalKeeper.DataCollector.Application.IO.Queries;
using GoalKeeper.DataCollector.Application.Mappers;
using GoalKeeper.DataCollector.Application.Ports;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Application.QueryHandlers
{
    public class MatchdayQueryHandler : IRequestHandler<MatchdayQuery, MatchdayDTO>
    {
        private readonly IMatchRepository _repository;

        public MatchdayQueryHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<MatchdayDTO> Handle(MatchdayQuery request, CancellationToken cancellationToken)
        {
            var matches = await _repository.Get(request.Matchday);
            
            return new MatchdayDTO
            {
                Matchday = request.Matchday,
                Matches = matches.MapOut()
            };
        }
    }
}
