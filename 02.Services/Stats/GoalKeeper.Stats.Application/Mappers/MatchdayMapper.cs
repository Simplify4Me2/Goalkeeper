using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class MatchdayMapper
    {
        public static MatchdayDTO MapOut(this Domain.ValueObjects.Matchday matchday)
        {
            return new MatchdayDTO
            {
                Day = matchday.Day,
                // Or does this "logic" belong in the Domain?? => Fo sho!!! TODO !!!
                IsOpeningMatchday = matchday.IsOpeningMatchday,
                IsClosingMatchday = matchday.IsClosingMatchday,
                Matches = matchday.Matches.MapOut()
            };
        }

        public static IEnumerable<MatchdayDTO> MapOut(this IEnumerable<Domain.ValueObjects.Matchday> matchdays)
            => matchdays.Select(matchday => MapOut(matchday));
    }
}
