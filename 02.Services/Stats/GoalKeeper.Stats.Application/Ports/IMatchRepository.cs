﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.Ports
{
    public interface IMatchRepository
    {
        Task<IEnumerable<Domain.Match>> Get(CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Match>> FindCurrentMatchday(CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Match>> FindByMatchday(int matchday, CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Match>> FindByTeamId(long teamId, CancellationToken cancellationToken);

        Task<bool> Save(Domain.Match match, CancellationToken cancellationToken);
    }
}
