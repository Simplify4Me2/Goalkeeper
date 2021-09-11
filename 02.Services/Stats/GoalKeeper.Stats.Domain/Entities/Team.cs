using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Domain
{
    public class Team
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public List<Player> Players { get; private set; } = new List<Player>();

        public Stadium Stadium { get; set; }

        public Team(long id, string name, Stadium stadium, List<Player> players)
        {
            Id = id;
            Name = name;
            Stadium = stadium;
            Players = players;
        }

        public string[] FormToString(List<Match> matches)
        {
            var returnValue = new string[4];
            int returnValueIndex = 3;
            for (int i = 0; i < 4; i++)
            {
                if (matches.Count == 0)
                {
                    returnValue[returnValueIndex] = "-";
                    returnValueIndex--;
                    continue;
                }
                var match = matches.Last();

                if (match.Score.Home == match.Score.Away)
                    returnValue[returnValueIndex] = "D";
                else if ((match.HomeTeam.Id == Id && match.Score.Home > match.Score.Away) || (match.AwayTeam.Id == Id && match.Score.Home < match.Score.Away))
                    returnValue[returnValueIndex] = "W";
                else
                    returnValue[returnValueIndex] = "L";

                matches.Remove(match);
                returnValueIndex--;
            }

            return returnValue;
        }
    }
}
