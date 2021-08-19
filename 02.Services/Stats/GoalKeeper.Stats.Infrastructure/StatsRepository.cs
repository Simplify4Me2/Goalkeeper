﻿using Dapper;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.ValueObjects;
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
            string sql = $"SELECT [Teams].[Id], [Teams].[Name], [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position] " +
                $"FROM [Stats].[Players] " +
                    $"INNER JOIN [Stats].[Teams] ON [Teams].[Id] = [Players].[TeamId] " +
                $"WHERE [Teams].[Id] = {id}";

            var sqlResult = await _dbConnection.QueryAsync<TeamDataModel, PlayerDataModel, TeamDataModel>(sql, (team, player) =>
            {
                team.Players.Add(player);
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
            string sql = $"SELECT [Teams].[Id], [Teams].[Name], [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position] " +
                $"FROM [Stats].[Players] " +
                    $"INNER JOIN [Stats].[Teams] ON [Teams].[Id] = [Players].[TeamId] " +
                $"WHERE [Teams].[Name] LIKE '%{name}%'";

            var sqlResult = await _dbConnection.QueryAsync<TeamDataModel, PlayerDataModel, TeamDataModel>(sql, (team, player) =>
            {
                team.Players.Add(player);
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
            string sql = "SELECT [Teams].[Id], [Teams].[Name] FROM [Stats].[Teams]" +
                "JOIN [Stats].[SeasonTeams] ON [Teams].[Id] = [SeasonTeams].[TeamId] " +
                "JOIN [Stats].[Seasons] ON [SeasonTeams].[SeasonId] = [Seasons].[Id] " +
                    "WHERE GETDATE() BETWEEN [Seasons].[StartUtc] AND [Seasons].[EndUtc]";

            var result = await _dbConnection.QueryAsync<TeamDataModel>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            return TeamDataModel.MapOut(result); 
        }

        public async Task<IEnumerable<Player>> GetPlayersByTeamId(long teamId, CancellationToken cancellationToken)
        {
            string sql = $"SELECT [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position] " +
                $"FROM [Stats].[Players] " +
                $"WHERE [Players].[TeamId] = {teamId}";

            var result = await _dbConnection.QueryAsync<Player>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            return result;
        }
    }
}
