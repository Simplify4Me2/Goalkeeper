namespace GoalKeeper.Stats.Domain.Entities
{
    public class Player
    {
        public long Id { get; set; }

        public long TeamId { get; set; }

        public Team Team { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ShirtNumber { get; set; }

        public string Position { get; set; }
    }
}
