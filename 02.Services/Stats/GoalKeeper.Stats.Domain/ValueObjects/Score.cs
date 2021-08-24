namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class Score
    {
        public int Home { get; }

        public int Away { get; }

        public Score(int homeScore, int awayScore)
        {
            Home = homeScore;
            Away = awayScore;
        }
    }
}
