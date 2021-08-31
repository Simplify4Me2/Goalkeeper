using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class MatchdayMapper
    {
        public static MatchdayDTO MapOut(this Domain.ValueObjects.MatchdayResults matchday)
        {
            return new MatchdayDTO
            {
                Day = matchday.Day,
                IsOpeningMatchday = matchday.IsOpeningMatchday,
                IsClosingMatchday = matchday.IsClosingMatchday,
                Matches = matchday.Matches.MapOut()
            };
        }

        public static UpcomingMatchdayDTO MapOut(this Domain.ValueObjects.UpcomingMatchday matchday)
        {
            return new UpcomingMatchdayDTO
            {
                Day = matchday.Day,
                IsOpeningMatchday = matchday.IsOpeningMatchday,
                IsClosingMatchday = matchday.IsClosingMatchday,
                Matches = matchday.Matches.MapOut()
            };
        }
    }
}
