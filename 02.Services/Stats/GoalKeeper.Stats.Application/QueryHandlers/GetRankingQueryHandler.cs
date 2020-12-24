using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetRankingQueryHandler : IRequestHandler<GetRankingQuery, RankingDTO>
    {
        public async Task<RankingDTO> Handle(GetRankingQuery request, CancellationToken cancellationToken)
        {
            Ranking ranking = new Ranking
            {
                Id = 1,
                Name = "Jupiler Pro League",
                Teams = new List<string> { "RSC Anderlecht", "Antwerp", "KRC Genk", "Club Brugge" }
            };
            return ranking.MapOut();
        }
    }
}
