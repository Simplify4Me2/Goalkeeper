using GoalKeeper.Stats.Application.IO.Exceptions;
using GoalKeeper.Stats.Domain;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class TeamDataModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public StadiumDataModel Stadium { get; set; }

        public List<PlayerDataModel> Players { get; set; } = new List<PlayerDataModel>();

        public static Team MapOut(TeamDataModel team)
        {
            if (team == null) throw new TeamNotFoundException(nameof(team));
            return new Team(team.Id, team.Name, StadiumDataModel.MapOut(team.Stadium), PlayerDataModel.MapOut(team.Players).ToList());
        }

        public static IEnumerable<Team> MapOut(IEnumerable<TeamDataModel> teams)
        => teams.Select(team => MapOut(team));
    }
}
