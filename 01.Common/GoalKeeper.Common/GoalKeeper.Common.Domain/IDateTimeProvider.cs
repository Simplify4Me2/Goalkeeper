using System;

namespace GoalKeeper.Common.Domain
{
    public interface IDateTimeProvider
    {
        DateTime Today { get; }
    }
}
