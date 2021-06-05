using System.Collections.Generic;

namespace GoalKeeper.Stats.Application.IO.DTOs
{
    public class MatchdayDTO
    {
        public int Day { get; set; }

        public IEnumerable<MatchDTO> Matches { get; set; }
    }
}
