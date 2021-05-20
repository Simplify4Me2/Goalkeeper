using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class TeamRankingMapper
    {
        public static TeamRankingDTO MapOut(this Domain.Entities.TeamRanking teamRanking)
        {
            return new TeamRankingDTO
            {
                TeamId = teamRanking.Team.Id,
                TeamName = teamRanking.Team.Name,
                Points = teamRanking.Points
            };
        }

        public static IEnumerable<TeamRankingDTO> MapOut(this IEnumerable<Domain.Entities.TeamRanking> teamRankings)
            => teamRankings.Select(teamRanking => MapOut(teamRanking));
    }
}
