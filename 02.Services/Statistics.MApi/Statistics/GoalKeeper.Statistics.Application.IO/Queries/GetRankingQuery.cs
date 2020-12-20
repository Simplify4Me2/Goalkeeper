using MediatR;
using System.Collections.Generic;

namespace GoalKeeper.Statistics.Application.IO.Queries
{
    public class GetRankingQuery : IRequest<List<object>>
    {
    }
}
