﻿using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class MatchdayMapper
    {
        public static MatchdayDTO MapOut(this Domain.Entities.Matchday matchday)
        {
            return new MatchdayDTO
            {
                Day = matchday.Day,
                // Or does this "logic" belong in the Domain??
                IsOpeningMatchday = matchday.Day == 1,
                IsClosingMatchday = matchday.Day == 34,
                Matches = matchday.Matches.MapOut()
            };
        }

        public static IEnumerable<MatchdayDTO> MapOut(this IEnumerable<Domain.Entities.Matchday> matchdays)
            => matchdays.Select(matchday => MapOut(matchday));
    }
}
