using GoalKeeper.Stats.Domain.Primitives;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class UpcomingMatchday : Matchday
    {
        public UpcomingMatchday(int day, List<Fixture> matches) : base(day)
        {
            Matches = matches;
        }

        public List<Fixture> Matches { get; set; }
    }
}
