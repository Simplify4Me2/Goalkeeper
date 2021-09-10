using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class TeamRankingMapper
    {
        public static TeamRankingDTO MapOut(this Domain.TeamRanking teamRanking)
        {
            return new TeamRankingDTO
            {
                TeamId = teamRanking.Team.Id,
                TeamName = teamRanking.Team.Name,
                Points = teamRanking.Points,
                GamesPlayed = teamRanking.GamesPlayed
            };
        }

        public static IEnumerable<TeamRankingDTO> MapOut(this IEnumerable<Domain.TeamRanking> teamRankings)
            => teamRankings.Select(teamRanking => MapOut(teamRanking));
    }
}
