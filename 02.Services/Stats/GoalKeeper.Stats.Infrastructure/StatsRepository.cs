﻿using Dapper;
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

        public async Task<Ranking> GetRanking(CancellationToken cancellationToken)
        {
            //var ranking = _eventStore.AggregateStream<Ranking>(1);

            //var foo = new EventSourcingRepository();
            //await foo.SaveAsync(new Guid());

            string sql = "SELECT [Id], [Name] FROM [Stats].[Teams]";

            var result = await _dbConnection.QueryAsync<Team>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            var random = new Random();
            Ranking ranking = new Ranking
            {
                Name = "Jupiler Pro League",
                TeamRankings = result.Select(team => new TeamRanking
                {
                    //Id = team.Id,
                    Team = team,
                    Points = random.Next(36, 76)
                }).ToList()
                //Teams = result.ToList()
            };

            return ranking;
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


        public async Task<IEnumerable<Player>> GetPlayersByTeamId(long teamId, CancellationToken cancellationToken)
        {
            string sql = $"SELECT [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position] " +
                $"FROM [Stats].[Players] " +
                $"WHERE [Players].[TeamId] = {teamId}";

            var result = await _dbConnection.QueryAsync<Player>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            return result;
        }

        Task<IEnumerable<object>> GetMatches(CancellationToken cancellationToken)
        {
            string sql =    "SELECT [Matches].[Id], [HomeTeamId], homeTeam.[Name] AS [HomeTeamName], [HomeTeamScore], [AwayTeamId], awayTeam.[Name] AS [AwayTeamName] [AwayTeamScore], [Matchday], [DateUtc] " + 
                            "FROM [Stats].[Matches] " +
                                $"INNER JOIN [Stats].[Teams] homeTeam ON [Stats].[Teams].[Id] = [Stats].[Matches].[HomeTeamId] " +
                                $"INNER JOIN [Stats].[Teams] awayTeam ON [Stats].[Teams].[Id] = [Stats].[Matches].[AwayTeamId]";

            var result = _dbConnection.QueryAsync<object>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            return result;
        }

    }
}
