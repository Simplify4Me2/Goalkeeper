using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class GetTeamByNameQuery : IRequest<TeamDTO>
    {
        public string Name { get; }

        public GetTeamByNameQuery(string name)
        {
            Name = name;
        }
    }
}
