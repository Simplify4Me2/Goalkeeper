using Dapper;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain;
using GoalKeeper.Stats.Infrastructure.DataModels;
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

        public async Task<Team> GetTeamById(long id, CancellationToken cancellationToken)
        {
            string sql = $@"SELECT [Teams].[Id], [Teams].[Name], [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position], [Stadiums].[Id], [Stadiums].[Name] 
                            FROM [Stats].[Teams] 
                                INNER JOIN [Stats].[Players] ON [Teams].[Id] = [Players].[TeamId] 
                                INNER JOIN [Stats].[Stadiums] ON [Teams].[StadiumId] = [Stadiums].[Id] 
                            WHERE [Teams].[Id] = {id}";

            var sqlResult = await _dbConnection.QueryAsync<TeamDataModel, PlayerDataModel, StadiumDataModel, TeamDataModel>(sql, (team, player, stadium) =>
            {
                team.Players.Add(player);
                team.Stadium = stadium;
                return team;
            }, cancellationToken);

            var result = sqlResult.GroupBy(team => team.Id).Select(group =>
            {
                var groupedTeam = group.First();
                groupedTeam.Players = group.Select(g => g.Players.Single()).ToList();
                return groupedTeam;
            });

            return TeamDataModel.MapOut(result.FirstOrDefault());
        }

        public async Task<Team> GetTeamByName(string name, CancellationToken cancellationToken)
        {
            string sql = $@"SELECT [Teams].[Id], [Teams].[Name], [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position], [Stadiums].[Id], [Stadiums].[Name] 
                                FROM [Stats].[Teams] 
                                    INNER JOIN [Stats].[Players] ON [Teams].[Id] = [Players].[TeamId] 
                                    INNER JOIN [Stats].[Stadiums] ON [Teams].[StadiumId] = [Stadiums].[Id] 
                                WHERE [Teams].[Name] LIKE '%{name}%'";

            var sqlResult = await _dbConnection.QueryAsync<TeamDataModel, PlayerDataModel, StadiumDataModel, TeamDataModel>(sql, (team, player, stadium) =>
            {
                team.Players.Add(player);
                team.Stadium = stadium;
                return team;
            }, cancellationToken);

            var result = sqlResult.GroupBy(team => team.Id).Select(group =>
            {
                var groupedTeam = group.First();
                groupedTeam.Players = group.Select(g => g.Players.Single()).ToList();
                return groupedTeam;
            });

            return TeamDataModel.MapOut(result.FirstOrDefault());
        }

        public async Task<IEnumerable<Team>> GetTeams(CancellationToken cancellationToken)
        {
            string sql = @"SELECT [Teams].[Id], [Teams].[Name], [Stadiums].[Id], [Stadiums].[Name] 
                            FROM [Stats].[Teams] 
                                JOIN [Stats].[SeasonTeams] ON [Teams].[Id] = [SeasonTeams].[TeamId] 
                                JOIN [Stats].[Seasons] ON [SeasonTeams].[SeasonId] = [Seasons].[Id] 
                                JOIN [Stats].[Stadiums] ON [Teams].[StadiumId] = [Stadiums].[Id] 
                            WHERE GETDATE() BETWEEN [Seasons].[StartUtc] AND [Seasons].[EndUtc]";

            var sqlResult = await _dbConnection.QueryAsync<TeamDataModel, StadiumDataModel, TeamDataModel>(sql, (team, stadium) => 
            { 
                team.Stadium = stadium; 
                return team; 
            }, cancellationToken);

            return TeamDataModel.MapOut(sqlResult);
        }

        public async Task<IEnumerable<Player>> GetPlayersByTeamId(long teamId, CancellationToken cancellationToken)
        {
            string sql = $@"SELECT [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position] 
                            FROM [Stats].[Players] 
                            WHERE [Players].[TeamId] = {teamId}";

            var result = await _dbConnection.QueryAsync<Player>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            return result;
        }
    }
}
