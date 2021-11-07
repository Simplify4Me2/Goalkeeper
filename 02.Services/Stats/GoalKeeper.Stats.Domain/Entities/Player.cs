using System;

namespace GoalKeeper.Stats.Domain
{
    public class Player : Person
    {
        public int ShirtNumber { get; }

        public string Position { get; }

        public string Nationality { get; set; }

        public Player(long id, string firstName, string lastName, string nationality, DateTime birthdate, DateTime today, int shirtNumber, string position)
            : base(id, firstName, lastName, birthdate, today)
        {
            ShirtNumber = shirtNumber;
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Nationality = nationality ?? throw new ArgumentNullException(nameof(nationality));
        }
    }
}
