using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class MatchMapper
    {
        public static MatchDTO MapOut(this Domain.ValueObjects.PlayedMatch match)
        {
            return new MatchDTO
            {
                Id = match.Id,
                HomeTeamId = match.HomeTeam.Id,
                HomeTeamName = match.HomeTeam.Name,
                HomeTeamScore = match.FinalScore.Home,
                AwayTeamId = match.AwayTeam.Id,
                AwayTeamName = match.AwayTeam.Name,
                AwayTeamScore = match.FinalScore.Away,
                Date = match.Date
            };
        }

        public static IEnumerable<MatchDTO> MapOut(this IEnumerable<Domain.ValueObjects.PlayedMatch> matches)
            => matches.Select(match => MapOut(match));
    }
}
