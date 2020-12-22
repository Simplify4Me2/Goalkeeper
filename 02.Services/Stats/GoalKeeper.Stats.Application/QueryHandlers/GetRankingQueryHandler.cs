using GoalKeeper.Stats.Application.IO.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetRankingQueryHandler : IRequestHandler<GetRankingQuery, List<object>>
    {
        public Task<List<object>> Handle(GetRankingQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
