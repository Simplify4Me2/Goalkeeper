﻿using System;

namespace GoalKeeper.DataCollector.Domain
{
    public class Match
    {
        public DateTime Date { get; set; }

        public int Matchday { get; set; }

        public string HomeTeamName { get; set; }

        public int? HomeTeamScore { get; set; }

        public string AwayTeamName { get; set; }

        public int? AwayTeamScore { get; set; }
    }
}
