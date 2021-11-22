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
        private readonly IMatchWebScraper _webScraper;

        public MatchdayQueryHandler(IMatchRepository repository, IMatchWebScraper webScraper)
        {
            _repository = repository;
            _webScraper = webScraper;
        }

        public async Task<MatchdayDTO> Handle(MatchdayQuery request, CancellationToken cancellationToken)
        {
            var matches = await _repository.Get(request.Matchday);
            if (matches.Length == 0)
            {
                matches = await _webScraper.Get(request.Matchday);
                await _repository.Save(matches);
            }
            return new MatchdayDTO
            {
                Matchday = request.Matchday,
                Matches = matches.MapOut()
            };
        }
    }
}
