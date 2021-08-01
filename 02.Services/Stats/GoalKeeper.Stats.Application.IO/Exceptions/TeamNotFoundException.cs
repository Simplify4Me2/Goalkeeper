using System;

namespace GoalKeeper.Stats.Application.IO.Exceptions
{
    public class TeamNotFoundException : Exception
    {
        public TeamNotFoundException(string message) : base(message)
        {

        }
    }
}
