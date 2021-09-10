using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class FindTeamByNameQuery : IRequest<TeamDTO>
    {
        public string Name { get; }

        public FindTeamByNameQuery(string name)
        {
            Name = name;
        }
    }
}
