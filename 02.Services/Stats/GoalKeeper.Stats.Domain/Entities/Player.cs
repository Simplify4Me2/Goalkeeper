using System;

namespace GoalKeeper.Stats.Domain.Entities
{
    public class Player : Person
    {
        public long Id { get; }

        public int ShirtNumber { get; }

        public string Position { get; }

        public Player(long id, string firstName, string lastName, DateTime birthdate, DateTime today, Team team, int shirtNumber, string position)
            : base(firstName, lastName, birthdate, today)
        {
            Id = id;
            ShirtNumber = shirtNumber;
            Position = position;
        }
    }
}
