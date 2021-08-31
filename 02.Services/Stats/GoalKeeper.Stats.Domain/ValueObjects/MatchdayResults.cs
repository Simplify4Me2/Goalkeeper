using GoalKeeper.Stats.Domain.Primitives;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class MatchdayResults : Matchday
    {
        public MatchdayResults(int day, List<PlayedMatch> results) : base(day)
        {
            Matches = results;
        }

        public List<PlayedMatch> Matches { get; set; }
    }
}
