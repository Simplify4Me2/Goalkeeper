using GoalKeeper.Stats.Application.IO.DTOs;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class RankingMapper
    {
        public static RankingDTO MapOut(this Domain.Entities.League league)
        {
            return new RankingDTO
            {
                CompetitionName = league.Name,
                TeamRankings = league.Table.MapOut().ToList()
            };
        }
    }
}
