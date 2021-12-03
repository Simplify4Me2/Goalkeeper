﻿using GoalKeeper.Common.Application;
using System;

namespace GoalKeeper.Stats.WebApi.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Today => DateTime.Today;
    }
}
