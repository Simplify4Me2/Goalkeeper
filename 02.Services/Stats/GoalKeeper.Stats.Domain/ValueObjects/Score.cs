using GoalKeeper.Stats.Domain.ValueObjects;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain
{
    public class Score
    {
        public int Home { get; }

        public int Away { get; }

        public List<Goal> Goals { get; set; }

        public Score(int homeScore, int awayScore, List<Goal> goals = null)
        {
            Home = homeScore;
            Away = awayScore;
            Goals = goals ?? new List<Goal>();
        }
    }
}
