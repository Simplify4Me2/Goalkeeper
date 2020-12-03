using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.MApi.Infrastructure.Entities
{
    public class TeamEntity : BaseEntity
    {
        public string Name { get; set; }

        public static Domain.Models.Team MapOut(TeamEntity team)
        {
            return new Domain.Models.Team
            {
                Name = team.Name
            };
        }

        public static List<Domain.Models.Team> MapOut(IEnumerable<TeamEntity> teams)
            => teams.Select(MapOut).ToList();
    }
}
