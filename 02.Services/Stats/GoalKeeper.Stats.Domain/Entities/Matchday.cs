using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Matchday
    {
        public Matchday(int day, IEnumerable<Match> matches)
        {
            Day = day;
            Matches = matches;
        }

        public int Day { get; }

        public IEnumerable<Match> Matches { get; }
    }
}
