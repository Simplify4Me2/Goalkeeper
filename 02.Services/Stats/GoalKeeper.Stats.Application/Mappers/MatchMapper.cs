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

        public static FixtureDTO MapOut(this Domain.ValueObjects.Fixture fixture)
        {
            return new FixtureDTO
            {
                Id = fixture.Id,
                HomeTeamId = fixture.HomeTeam.Id,
                HomeTeamName = fixture.HomeTeam.Name,
                AwayTeamId = fixture.AwayTeam.Id,
                AwayTeamName = fixture.AwayTeam.Name,
                Date = fixture.ScheduledDate
            };
        }

        public static IEnumerable<FixtureDTO> MapOut(this IEnumerable<Domain.ValueObjects.Fixture> fixtures)
            => fixtures.Select(fixture => MapOut(fixture));
    }
}
