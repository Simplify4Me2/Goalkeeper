using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class GetMatchdayQuery : IRequest<MatchdayDTO>
    {
        public int Day { get; }

        public GetMatchdayQuery(int day)
        {
            Day = day;
        }
    }
}
