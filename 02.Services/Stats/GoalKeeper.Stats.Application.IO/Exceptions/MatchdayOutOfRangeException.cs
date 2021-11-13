using System;

namespace GoalKeeper.Stats.Application.IO.Exceptions
{
    public class MatchdayOutOfRangeException : Exception
    {
        public MatchdayOutOfRangeException(string message) : base(message)
        {

        }
    }
}
