using GoalKeeper.Stats.Domain.Primitives;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Player
    {
        public long Id { get; }

        private Person Name { get; }

        public string FirstName => Name.Firstname;

        public string LastName => Name.LastName;

        public int ShirtNumber { get; }

        public string Position { get; }

        public Player(long id, Person name, Team team, int shirtNumber, string position)
        {
            Id = id;
            Name = name;
            ShirtNumber = shirtNumber;
            Position = position;
        }
    }
}
