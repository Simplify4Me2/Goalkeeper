using System.Collections.Generic;

namespace GoalKeeper.Stats.Application.IO.DTOs
{
    public class UpcomingMatchdayDTO
    {
        public int Day { get; set; }

        public bool IsOpeningMatchday { get; set; }

        public bool IsClosingMatchday { get; set; }

        public IEnumerable<FixtureDTO> Matches { get; set; }
    }
}
