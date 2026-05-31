using Goalkeeper.Server.Application.DTOs;
using Goalkeeper.Server.Application.Interfaces;
using Goalkeeper.Server.Core.Interfaces;
using Goalkeeper.Server.Application.DTOs.Mappers;

namespace Goalkeeper.Server.Application.Queries.GetAllGroupStandings;

public class GetAllGroupStandingsHandler(IStandingsRepository repository)
    : IQueryHandler<GetAllGroupStandingsQuery, IEnumerable<GroupStandingsDto>>
{
    public async Task<IEnumerable<GroupStandingsDto>> HandleAsync(GetAllGroupStandingsQuery query, CancellationToken cancellationToken)
    {
        var all = await repository.GetAllAsync(cancellationToken);
        return all
            .GroupBy(s => s.GroupName)
            .OrderBy(g => g.Key)
            .Select(g => new GroupStandingsDto
            {
                GroupName = g.Key,
                Standings = g
                    .OrderByDescending(s => s.Points)
                    .ThenByDescending(s => s.GoalsFor - s.GoalsAgainst)
                    .ThenByDescending(s => s.GoalsFor)
                    .Select(s => s.ToDto())
            });
    }
}
