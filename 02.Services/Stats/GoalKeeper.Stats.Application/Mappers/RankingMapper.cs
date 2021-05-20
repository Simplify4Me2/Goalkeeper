using GoalKeeper.Stats.Application.IO.DTOs;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class RankingMapper
    {
        public static RankingDTO MapOut(this Domain.Entities.Ranking ranking)
        {
            return new RankingDTO
            {
                CompetitionName = ranking.Name,
                TeamRankings = ranking.TeamRankings.MapOut().ToList()
            };
        }
    }
}
