using System;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class ScheduledMatch : Match
    {
        public DateTime ScheduledDate { get; set; }

        public ScheduledMatch(long id, Team homeTeam, Team awayTeam, DateTime date, int matchday) : base(id, homeTeam, awayTeam, matchday)
        {
            ScheduledDate = date;
        }
    }
}
