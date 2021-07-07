using GoalKeeper.Stats.Domain.Primitives;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Player
    {
        public long Id { get; }

        private Person Person { get; }

        public string FirstName => Person.Firstname;

        public string LastName => Person.LastName;

        public int ShirtNumber { get; }

        public string Position { get; }

        public Player(long id, Person person, Team team, int shirtNumber, string position)
        {
            Id = id;
            Person = person;
            ShirtNumber = shirtNumber;
            Position = position;
        }
    }
}
