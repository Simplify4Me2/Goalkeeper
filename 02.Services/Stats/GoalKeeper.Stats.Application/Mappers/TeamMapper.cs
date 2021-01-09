using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class TeamMapper
    {
        public static TeamDTO MapOut(this Domain.Entities.Team team)
        {
            return new TeamDTO
            {
                Id = team.Id,
                Name = team.Name,
                Players = team.Players.MapOut()
            };
        }

        public static IEnumerable<TeamDTO> MapOut(this IEnumerable<Domain.Entities.Team> teams)
            => teams.Select(team => MapOut(team));
    }
}
