using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class GetPlayersByTeamIdQuery : IRequest<IEnumerable<PlayerDTO>>
    {
        public long Id { get; }

        public GetPlayersByTeamIdQuery(long id)
        {
            Id = id;
        }
    }
}
