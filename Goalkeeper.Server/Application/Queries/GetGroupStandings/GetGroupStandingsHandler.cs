using Goalkeeper.Server.Application.DTOs;
using Goalkeeper.Server.Application.Interfaces;
using Goalkeeper.Server.Core.Interfaces;
using Goalkeeper.Server.Application.DTOs.Mappers;

namespace Goalkeeper.Server.Application.Queries.GetGroupStandings;

public class GetGroupStandingsHandler(IStandingsRepository repository) : IQueryHandler<GetGroupStandingsQuery, IEnumerable<TeamStandingDto>>
{
    public async Task<IEnumerable<TeamStandingDto>> HandleAsync(GetGroupStandingsQuery query, CancellationToken cancellationToken)
    {
        var standings = await repository.GetByGroupAsync(query.GroupName, cancellationToken);
        return standings
            .OrderByDescending(s => s.Points)
            .ThenByDescending(s => s.GoalsFor - s.GoalsAgainst)
            .ThenByDescending(s => s.GoalsFor)
            .Select(s => s.ToDto());
    }
}
