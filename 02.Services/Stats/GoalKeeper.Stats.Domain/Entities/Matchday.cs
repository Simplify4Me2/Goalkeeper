using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Matchday
    {
        public int Day { get; set; }

        public IEnumerable<Match> Matches { get; set; }
    }
}
