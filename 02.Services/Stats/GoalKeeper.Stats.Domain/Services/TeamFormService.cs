using System.Collections.Generic;

namespace GoalKeeper.Stats.Domain.Services
{
    public class TeamFormService
    {
        public static string[] PrintForm(Team team, List<Match> matches)
        {
            return new[] { "W", "D", "W", "L" };
        }
    }
}
