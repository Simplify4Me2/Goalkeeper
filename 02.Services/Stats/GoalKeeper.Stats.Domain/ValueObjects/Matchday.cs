using System;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain
{
    public class Matchday
    {
        private const int _matches = 34;

        public Matchday(int day, List<Match> matches)
        {
            Day = day;
            Matches = matches ?? throw new ArgumentNullException(nameof(matches));
        }

        public List<Match> Matches { get; }

        public int Day { get; }

        public bool IsOpeningMatchday => Day == 1;

        public bool IsClosingMatchday => Day == _matches;
    }
}
