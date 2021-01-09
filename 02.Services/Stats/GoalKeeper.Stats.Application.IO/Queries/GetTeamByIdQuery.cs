using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class GetTeamByIdQuery : IRequest<TeamDTO>
    {
        public long Id { get; }

        public GetTeamByIdQuery(long id)
        {
            Id = id;
        }
    }
}
