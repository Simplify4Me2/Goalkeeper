using GoalKeeper.Stats.Application.IO.Commands;
using System;

namespace GoalKeeper.Stats.Application.IO.CommandModels
{
    public class MatchPlayedModel
    {
        public string HomeTeamName { get; set; }

        public int HomeTeamScore { get; set; }

        public string AwayTeamName { get; set; }

        public int AwayTeamScore { get; set; }

        public DateTime Date { get; set; }

        public int Matchday { get; set; }

        public MatchPlayedCommand ToCommand()
        {
            return new MatchPlayedCommand(HomeTeamName, HomeTeamScore, AwayTeamName, AwayTeamScore, Date, Matchday);
        }
    }
}
