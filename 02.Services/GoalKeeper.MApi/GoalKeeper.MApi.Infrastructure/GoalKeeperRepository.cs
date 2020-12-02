using Dapper;
using GoalKeeper.MApi.Application.Ports;
using GoalKeeper.MApi.Domain.Models;
using GoalKeeper.MApi.Infrastructure.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.MApi.Infrastructure
{
    public class GoalKeeperRepository : IGoalKeeperRepository
    {
        private readonly IDbConnection _connection;

        public GoalKeeperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Fixture>> GetFixtures(CancellationToken cancellationToken)
        {
            var foo = new List<Fixture>
            {
                new Fixture { Id = 1, HomeTeam = "FC De Kampioenen", AwayTeam = "VK Heuvel Lo", HomeScore = 3, AwayScore = 1 },
                new Fixture { Id = 2, HomeTeam = "RSC Anderlecht", AwayTeam = "STVV", HomeScore = 2, AwayScore = 2 },
                new Fixture { Id = 3, HomeTeam = "Zulte Waregem", AwayTeam = "Cercle Brugge", HomeScore = 4, AwayScore = 0 },
                new Fixture { Id = 4, HomeTeam = "RC Genk", AwayTeam = "OHL", HomeScore = 0, AwayScore = 1 },
            };

            return await Task.Run(() => foo);
        }

        public async Task<List<Domain.Models.Team>> GetTeams(CancellationToken cancellation)
        {
            var foo = await _connection.QueryAsync<TeamEntity>("SELECT * FROM GoalKeeper.Teams");

            return TeamEntity.MapOut(foo);
        }
    }
}
