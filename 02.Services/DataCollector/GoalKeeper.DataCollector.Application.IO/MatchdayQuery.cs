using MediatR;

namespace GoalKeeper.DataCollector.Application.IO
{
    public class MatchdayQuery : IRequest<MatchdayQueryResponse>
    {
        public int Matchday { get; }

        public MatchdayQuery(int matchday)
        {
            Matchday = matchday;
        }

    }
}
