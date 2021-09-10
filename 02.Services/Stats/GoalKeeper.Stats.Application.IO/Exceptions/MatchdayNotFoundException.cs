using System;

namespace GoalKeeper.Stats.Application.IO.Exceptions
{
    public class MatchdayNotFoundException : Exception
    {
        public MatchdayNotFoundException(string message) : base(message)
        {

        }
    }
}
