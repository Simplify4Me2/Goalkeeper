﻿using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Domain
{
    public class League
    {
        private const int _pointsForWin = 3;
        private const int _pointsForDraw = 1;
        private const int _pointsForLoss = 0;

        public string Name { get; }
        private List<Team> Teams { get; }
        private List<Match> Matches { get; }

        public League(string name, List<Team> teams, List<Match> matches)
        {
            Name = name;
            Teams = teams;
            Matches = matches;
        }

        public List<TeamRanking> Table { get
            {
                List<TeamRanking> table = new List<TeamRanking>();
                foreach (Team team in Teams)
                {
                    var matches = Matches.Where(match => team.Id == match.HomeTeam.Id || team.Id == match.AwayTeam.Id);
                    int points = (from match in matches
                                  select DeterminePoints(team, match)).Sum();
                    int matchesPlayed = matches.Where(match => match.Score != null).Count();

                    TeamRanking teamRanking = new TeamRanking(team, points, matchesPlayed);
                    table.Add(teamRanking);
                }
                return table.OrderByDescending(ranking => ranking.Points).ToList();
            }
        }

        private int DeterminePoints(Team team, Match match)
        {
            if (match.Status != Status.Played)
                return 0;
            if (match.Score.Home == match.Score.Away)
                return _pointsForDraw;
            if (team.Id == match.HomeTeam.Id && match.Score.Home > match.Score.Away)
                return _pointsForWin;
            if (team.Id == match.AwayTeam.Id && match.Score.Home < match.Score.Away)
                return _pointsForWin;
            return _pointsForLoss;
        }
    }
}
