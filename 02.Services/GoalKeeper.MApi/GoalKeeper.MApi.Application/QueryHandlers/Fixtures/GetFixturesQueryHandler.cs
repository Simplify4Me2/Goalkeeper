using GoalKeeper.MApi.Application.IO.Queries.Fixtures;
using GoalKeeper.MApi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.MApi.Application.QueryHandlers.Fixtures
{
    public class GetFixturesQueryHandler : IRequestHandler<GetFixturesQuery, List<Fixture>>
    {
        
        public async Task<List<Fixture>> Handle(GetFixturesQuery request, CancellationToken cancellationToken)
        {
            var foo = new List<Fixture>
            {
                new Fixture { Id = new Guid("00000000-0000-0000-0000-000000000001"), HomeTeam = "FC De Kampioenen", AwayTeam = "VK Heuvel Lo", HomeScore = 3, AwayScore = 1 },
                new Fixture { Id = new Guid("00000000-0000-0000-0000-000000000002"), HomeTeam = "RSC Anderlecht", AwayTeam = "STVV", HomeScore = 2, AwayScore = 2 },
                new Fixture { Id = new Guid("00000000-0000-0000-0000-000000000003"), HomeTeam = "Zulte Waregem", AwayTeam = "Cercle Brugge", HomeScore = 4, AwayScore = 0 },
                new Fixture { Id = new Guid("00000000-0000-0000-0000-000000000004"), HomeTeam = "RC Genk", AwayTeam = "OHL", HomeScore = 0, AwayScore = 1 },
            };

            return await Task.Run(() => foo);
        }
    }
}
