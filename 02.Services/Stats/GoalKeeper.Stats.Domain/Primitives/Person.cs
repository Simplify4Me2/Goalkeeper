using System;

namespace GoalKeeper.Stats.Domain.Primitives
{
    public abstract class Person
    {
        public Person(long id, string firstname, string lastName, DateTime birthdate, DateTime today)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastName;
            Birthdate = birthdate;
            _today = today;
        }

        public long Id { get; }
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
