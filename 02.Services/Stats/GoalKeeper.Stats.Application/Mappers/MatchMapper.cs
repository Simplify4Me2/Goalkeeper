using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class MatchMapper
    {
        public static MatchDTO MapOut(this Domain.Match match)
        {
            return new MatchDTO
            {
                Id = match.Id,
                HomeTeamId = match.HomeTeam.Id,
                HomeTeamName = match.HomeTeam.Name,
                HomeTeamScore = match.Status == Domain.Status.Played ? match.Score.Home.ToString() : null,
                AwayTeamId = match.AwayTeam.Id,
                AwayTeamName = match.AwayTeam.Name,
                AwayTeamScore = match.Status == Domain.Status.Played ? match.Score.Away.ToString() : null,
                Date = match.Date,
                IsPlayed = match.Status == Domain.Status.Played
            };
        }

        public static IEnumerable<MatchDTO> MapOut(this IEnumerable<Domain.Match> matches)
            => matches.Select(match => MapOut(match));

        //public static MatchDTO MapOut(this Domain.Match match)
        //{
        //    return new MatchDTO
        //    {
        //        Id = match.Id,
        //        HomeTeamId = match.HomeTeam.Id,
        //        HomeTeamName = match.HomeTeam.Name,
        //        AwayTeamId = match.AwayTeam.Id,
        //        AwayTeamName = match.AwayTeam.Name,
        //        Date = match.Date,
        //        IsPlayed = match.Status == Domain.Status.Played
        //    };
        //}

        //public static IEnumerable<MatchDTO> MapOut(this IEnumerable<Domain.Match> fixtures)
        //    => fixtures.Select(fixture => MapOut(fixture));
    }
}
