using Dapper;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using GoalKeeper.Stats.Infrastructure.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Infrastructure
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IDbConnection _dbConnection;

        public MatchRepository(IDbConnection dbConnection)
{
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Match>> Get(CancellationToken cancellationToken)
        {
            string sql = "SELECT [match].[Id], [HomeTeamScore], [AwayTeamScore], [Matchday], [DateUtc] AS Date, " +
                                "[homeTeam].[Id], [homeTeam].[Name], " +
                                "[awayTeam].[Id], [awayTeam].[Name] " +
                            "FROM [Stats].[Matches] [match] " +
                                "INNER JOIN [Stats].[Teams] [homeTeam] ON [homeTeam].[Id] = [match].[HomeTeamId] " +
                                "INNER JOIN [Stats].[Teams] [awayTeam] ON [awayTeam].[Id] = [match].[AwayTeamId] " +
                                "JOIN [Stats].[Seasons] ON [Seasons].[Id] = (SELECT MAX([Id]) FROM [Stats].[Seasons]) " +
                            "WHERE [DateUtc] BETWEEN [Seasons].[StartUtc] AND [Seasons].[EndUtc]";

            var sqlResult = await _dbConnection.QueryAsync<MatchDataModel, TeamDataModel, TeamDataModel, MatchDataModel>(sql, (match, homeTeam, awayTeam) => {
                match.HomeTeam = homeTeam;
                match.AwayTeam = awayTeam;
                return match;
            }, cancellationToken);
            return MatchDataModel.MapOut(sqlResult);
        }

        public async Task<bool> Save(Match match, CancellationToken cancellationToken)
        {
            string sql = "INSERT INTO [Stats].[Matches] " +
                "([HomeTeamId] ,[HomeTeamScore] ,[AwayTeamId] ,[AwayTeamScore] ,[Matchday], [DateUtc] ,[CreatedUtc] ,[CreatedBy] ,[ModifiedUtc] ,[ModifiedBy]) " +
                "VALUES " +
                    $"({match.HomeTeam.Id}, {match.HomeTeamScore}, {match.AwayTeam.Id}, {match.AwayTeamScore}, {match.Matchday}, {DateTime.Now}, {DateTime.Now}, {"TODO"}, {DateTime.Now}, {"TODO"})";

            var sqlresult = await _dbConnection.ExecuteAsync(sql, cancellationToken);

            return sqlresult == 1;
        }
    }
}
