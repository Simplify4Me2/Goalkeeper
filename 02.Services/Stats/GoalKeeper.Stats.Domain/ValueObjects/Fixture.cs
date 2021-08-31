using GoalKeeper.Stats.Domain.Primitives;
using System;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class Fixture : Match
    {
        public DateTime ScheduledDate { get; set; }

        public Fixture(long id, Team homeTeam, Team awayTeam, DateTime date, int matchday) : base(id, homeTeam, awayTeam, matchday)
        {
            ScheduledDate = date;
        }
    }
}
