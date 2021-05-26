using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class MatchMapper
    {
        public static MatchDTO MapOut(this Domain.Entities.Match match)
        {
            return new MatchDTO
            {
                Id = match.Id,
                HomeTeamName = match.HomeTeam.Name,
                HomeTeamScore = match.HomeTeamScore,
                AwayTeamName = match.AwayTeam.Name,
                AwayTeamScore = match.AwayTeamScore,
                Matchday = match.Matchday,
                Date = match.Date
            };
        }

        public static IEnumerable<MatchDTO> MapOut(this IEnumerable<Domain.Entities.Match> matches)
            => matches.Select(match => MapOut(match));
    }
}
