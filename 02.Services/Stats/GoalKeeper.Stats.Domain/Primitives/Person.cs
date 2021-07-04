using GoalKeeper.Common.Domain;
using System;

namespace GoalKeeper.Stats.Domain.Primitives
{
    public class Person
    {
        public Person(string firstname, string lastName, DateTime birthdate, IDateTimeProvider dateTimeProvider)
        {
            Firstname = firstname;
            LastName = lastName;
            Birthdate = birthdate;
            _dateTimeProvider = dateTimeProvider;
        }

        public string Firstname { get; }
        public string LastName { get; }
        private DateTime Birthdate { get; }

        private readonly IDateTimeProvider _dateTimeProvider;

        public int Age
        {
            get
            {
                return _dateTimeProvider.Today.Year - Birthdate.Year;
            }
        }
    }
}
