using GoalKeeper.Stats.Application.IO.DTOs;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class RankingMapper
    {
        public static RankingDTO MapOut(this Domain.Entities.Ranking ranking)
        {
            return new RankingDTO
            {
                Id = ranking.Id,
                CompetitionName = ranking.Name
                //Teams = ranking.TeamRankings
            };
        }
    }
}
