using GoalKeeper.Stats.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class TeamDataModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public static Team MapOut(TeamDataModel team)
        => new Team(team.Id, team.Name, team.Players);

        public static IEnumerable<Team> MapOut(IEnumerable<TeamDataModel> teams)
        => teams.Select(team => MapOut(team));
    }
}
