﻿using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetMatchesQueryHandler : IRequestHandler<GetMatchesQuery, IEnumerable<MatchDTO>>
    {
        private readonly IMatchRepository _repository;

        public GetMatchesQueryHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MatchDTO>> Handle(GetMatchesQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.Get(cancellationToken);
            return data.MapOut();
        }
    }
}
