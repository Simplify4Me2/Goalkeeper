using Dapper;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using GoalKeeper.Stats.Infrastructure.EventStore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Infrastructure
{
    public class StatsRepository : IStatsRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly IEventStore _eventStore;

        public StatsRepository(IDbConnection dbConnection, IEventStore eventStore)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public Task<Ranking> GetRanking(CancellationToken cancellationToken)
        {
            var ranking = _eventStore.AggregateStream<Ranking>(1);

            //Ranking ranking = new Ranking
            //{
            //    Id = 1,
            //    Name = "Jupiler Pro League",
            //    Teams = new List<string> { "RSC Anderlecht", "Antwerp", "KRC Genk", "Club Brugge" }
            //};

            //var foo = new EventSourcingRepository();
            //await foo.SaveAsync(new Guid());

            return Task.Run(() => ranking);
        }

        public async Task<Team> GetTeamById(long id, CancellationToken cancellationToken)
        {
            string sql = $"SELECT [Teams].[Id], [Teams].[Name], [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position] " +
                $"FROM [Stats].[Players] " +
                    $"INNER JOIN [Stats].[Teams] ON [Teams].[Id] = [Players].[TeamId] " +
                $"WHERE [Teams].[Id] = {id}";

            var sqlResult = await _dbConnection.QueryAsync<Team, Player, Team>(sql, (team, player) =>
            {
                team.Players.Add(player);
                return team;
            });

            var result = sqlResult.GroupBy(team => team.Id).Select(group =>
            {
                var groupedTeam = group.First();
                groupedTeam.Players = group.Select(g => g.Players.Single()).ToList();
                return groupedTeam;
            });

            return result.FirstOrDefault();
        }

        public Task<IEnumerable<Team>> GetTeams(CancellationToken cancellationToken)
        {
            string sql = "SELECT [Id], [Name] FROM [Stats].[Teams]";

            var result = _dbConnection.QueryAsync<Team>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            return result;
        }
    }
}
