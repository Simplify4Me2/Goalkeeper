using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Infrastructure
{
    public class StatsRepository : IStatsRepository
    {
        public async Task<Ranking> GetRanking(CancellationToken cancellationToken)
        {
            Ranking ranking = new Ranking
            {
                Id = 1,
                Name = "Jupiler Pro League",
                Teams = new List<string> { "RSC Anderlecht", "Antwerp", "KRC Genk", "Club Brugge" }
            };

            return ranking;
        }
    }
}
