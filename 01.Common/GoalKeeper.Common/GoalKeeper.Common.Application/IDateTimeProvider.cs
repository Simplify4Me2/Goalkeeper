using System;

namespace GoalKeeper.Common.Application
{
    public interface IDateTimeProvider
    {
        DateTime Today { get; }
    }
}
