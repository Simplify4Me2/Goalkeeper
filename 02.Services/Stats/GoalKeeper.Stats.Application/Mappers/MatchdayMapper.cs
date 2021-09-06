using GoalKeeper.Stats.Application.IO.DTOs;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class MatchdayMapper
    {
        public static MatchdayDTO MapOut(this Domain.Matchday matchday)
        {
            return new MatchdayDTO
            {
                Day = matchday.Day,
                IsOpeningMatchday = matchday.IsOpeningMatchday,
                IsClosingMatchday = matchday.IsClosingMatchday,
                Matches = matchday.Matches.MapOut()
            };
        }
    }
}
