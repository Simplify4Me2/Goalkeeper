using GoalKeeper.Stats.Domain.Primitives;
using System;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class PlayedMatch : Match
    {
        public Score FinalScore { get; }

        public DateTime Date { get; }

        public PlayedMatch(long id, Team homeTeam, Team awayTeam, Score score, DateTime date, int matchday) : base(id, homeTeam, awayTeam, matchday)
        {
            FinalScore = score;
            Date = date;
        }

        public override bool IsPlayed => true;
    }
}
