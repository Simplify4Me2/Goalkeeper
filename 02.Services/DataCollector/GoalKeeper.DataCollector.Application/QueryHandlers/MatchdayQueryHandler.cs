using GoalKeeper.DataCollector.Application.IO;
using GoalKeeper.DataCollector.Application.Ports;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Application.QueryHandlers
{
    public class MatchdayQueryHandler : IRequestHandler<MatchdayQuery, MatchdayQueryResponse>
    {
        private readonly IMatchRepository _repository;
        private readonly IMatchWebScraper _webScraper;

        public MatchdayQueryHandler(IMatchRepository repository, IMatchWebScraper webScraper)
        {
            _repository = repository;
            _webScraper = webScraper;
        }

        public Task<MatchdayQueryResponse> Handle(MatchdayQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
