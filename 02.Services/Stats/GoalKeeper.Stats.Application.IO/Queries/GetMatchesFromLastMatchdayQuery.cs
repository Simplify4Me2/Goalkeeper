using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class GetMatchesFromLastMatchdayQuery : IRequest<IEnumerable<MatchDTO>>
    {
    }
}
