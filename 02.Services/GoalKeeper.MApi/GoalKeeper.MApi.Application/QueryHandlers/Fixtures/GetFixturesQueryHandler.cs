using GoalKeeper.MApi.Application.IO.DTOs;
using GoalKeeper.MApi.Application.IO.Queries.Fixtures;
using GoalKeeper.MApi.Application.Mappers;
using GoalKeeper.MApi.Application.Ports;
using GoalKeeper.MApi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.MApi.Application.QueryHandlers.Fixtures
{
    public class GetFixturesQueryHandler : IRequestHandler<GetFixturesQuery, List<FixtureDTO>>
    {
        private readonly IGoalKeeperRepository _repository;

        public GetFixturesQueryHandler(IGoalKeeperRepository goalKeeperRepository)
        {
            _repository = goalKeeperRepository;
        }

        public async Task<List<FixtureDTO>> Handle(GetFixturesQuery request, CancellationToken cancellationToken)
        {
            var foo = new List<Fixture>
            {
                new Fixture { Id = 1, HomeTeam = "FC De Kampioenen", AwayTeam = "VK Heuvel Lo", HomeScore = 3, AwayScore = 1 },
                new Fixture { Id = 2, HomeTeam = "RSC Anderlecht", AwayTeam = "STVV", HomeScore = 2, AwayScore = 2 },
                new Fixture { Id = 3, HomeTeam = "Zulte Waregem", AwayTeam = "Cercle Brugge", HomeScore = 4, AwayScore = 0 },
                new Fixture { Id = 4, HomeTeam = "RC Genk", AwayTeam = "OHL", HomeScore = 0, AwayScore = 1 },
            };

            var data = await _repository.GetFixtures(cancellationToken);

            var test = await Task.Run(() => _repository.GetTeams(cancellationToken));

            return foo.MapOut();
        }
    }
}
