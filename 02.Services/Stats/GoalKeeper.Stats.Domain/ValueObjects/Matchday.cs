using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class Matchday
    {
        private const int _matches = 34;

        public Matchday(int day, IEnumerable<PlayedMatch> matches)
        {
            Day = day;
            Matches = matches;
        }

        public int Day { get; }

        public IEnumerable<PlayedMatch> Matches { get; }

        public bool IsOpeningMatchday => Day == 1;

        public bool IsClosingMatchday => Day == _matches;
    }
}
