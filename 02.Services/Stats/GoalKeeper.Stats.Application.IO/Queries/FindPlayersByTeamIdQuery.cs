using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;
using System.Collections.Generic;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class FindPlayersByTeamIdQuery : IRequest<IEnumerable<PlayerDTO>>
    {
        public long Id { get; }

        public FindPlayersByTeamIdQuery(long id)
        {
            Id = id;
        }
    }
}
