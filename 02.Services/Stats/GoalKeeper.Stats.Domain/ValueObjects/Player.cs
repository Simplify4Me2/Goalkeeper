using GoalKeeper.Stats.Domain.Primitives;
using System;

namespace GoalKeeper.Stats.Domain.ValueObjects
{
    public class Player : Person
    {
        public int ShirtNumber { get; }

        public string Position { get; }

        public Player(long id, string firstName, string lastName, DateTime birthdate, DateTime today, int shirtNumber, string position)
            : base(id, firstName, lastName, birthdate, today)
        {
            ShirtNumber = shirtNumber;
            Position = position;
        }
    }
}
