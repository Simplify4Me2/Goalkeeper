namespace GoalKeeper.Stats.Domain.Primitives
{
    public abstract class Matchday
    {
        private const int _matches = 34;

        public Matchday(int day)
        {
            Day = day;
        }

        public int Day { get; }

        public bool IsOpeningMatchday => Day == 1;

        public bool IsClosingMatchday => Day == _matches;
    }
}
