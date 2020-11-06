using System;

namespace GoalKeeper.MApi.Domain.Models
{
    public class Fixture
    {
        public Guid Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public uint HomeScore { get; set; }

        public uint AwayScore { get; set; }
    }
}
