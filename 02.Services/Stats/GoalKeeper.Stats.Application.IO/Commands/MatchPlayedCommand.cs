using MediatR;
using System;

namespace GoalKeeper.Stats.Application.IO.Commands
{
    public class MatchPlayedCommand : IRequest<bool>
    {
        public string HomeTeamName { get; set; }

        public int HomeTeamScore { get; set; }

        public string AwayTeamName { get; set; }

        public int AwayTeamScore { get; set; }

        public DateTime Date { get; set; }

        public int Matchday { get; set; }

        public MatchPlayedCommand(string homeTeamName, int homeTeamScore, string awayTeamName, int awayTeamScore, DateTime date, int matchday)
        {
            HomeTeamName = homeTeamName;
            HomeTeamScore = homeTeamScore;
            AwayTeamName = awayTeamName;
            AwayTeamScore = awayTeamScore;
            Date = date;
            Matchday = matchday;
        }
    }
}
