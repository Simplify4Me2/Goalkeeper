using GoalKeeper.DataCollector.Application.IO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.DataCollector.Application
{
    public class MatchdayQueryHandler : IRequestHandler<MatchdayQuery, MatchdayQueryResponse>
    {
        public Task<MatchdayQueryResponse> Handle(MatchdayQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
