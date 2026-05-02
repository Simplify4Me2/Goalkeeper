using Goalkeeper.Server.Core;
using Goalkeeper.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Goalkeeper.Server.Infrastructure.Repositories;

public class TeamsRepository(GoalkeeperDbContext context) : ITeamsRepository
{
    public async Task<IEnumerable<Team>> Get(CancellationToken cancellationToken)
        => await context.Teams.ToListAsync(cancellationToken);
}
