using GoalKeeper.Stats.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class TeamDataModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<PlayerDataModel> Players { get; set; } = new List<PlayerDataModel>();

        public static Team MapOut(TeamDataModel team)
        => new Team(team.Id, team.Name, PlayerDataModel.MapOut(team.Players).ToList());

        public static IEnumerable<Team> MapOut(IEnumerable<TeamDataModel> teams)
        => teams.Select(team => MapOut(team));
    }
}
