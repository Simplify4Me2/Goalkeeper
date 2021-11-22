using GoalKeeper.DataCollector.Application.IO.DTOs;
using MediatR;

namespace GoalKeeper.DataCollector.Application.IO.Queries
{
    public class MatchdayQuery : IRequest<MatchdayDTO>
    {
        public int Matchday { get; }

        public MatchdayQuery(int matchday)
        {
            Matchday = matchday;
        }

    }
}
