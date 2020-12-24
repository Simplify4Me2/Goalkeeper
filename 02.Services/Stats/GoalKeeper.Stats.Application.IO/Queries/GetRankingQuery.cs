using MediatR;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class GetRankingQuery : IRequest<List<object>>
    {
    }
}
