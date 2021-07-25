using System;

namespace GoalKeeper.Stats.Domain.Entities
{
    public abstract class Person
    {
        public Person(string firstname, string lastName, DateTime birthdate, DateTime today)
        {
            Firstname = firstname;
            Lastname = lastName;
            Birthdate = birthdate;
            _today = today;
        }

        public string Firstname { get; }
        public string Lastname { get; }
        private DateTime Birthdate { get; }

        private readonly DateTime _today;

        public int Age
        {
            get
            {
                return _today.Year - Birthdate.Year;
            }
        }
    }
}
