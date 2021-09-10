using Dapper;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain;
using GoalKeeper.Stats.Infrastructure.DataModels;
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
                                "[homeTeam].[Id], [homeTeam].[Name], [homeStadium].[Id], [homeStadium].[Name], " +
                                "[awayTeam].[Id], [awayTeam].[Name], [awayStadium].[Id], [awayStadium].[Name] " +
                            "FROM [Stats].[Matches] [match] " +
                                "INNER JOIN [Stats].[Teams] [homeTeam] ON [homeTeam].[Id] = [match].[HomeTeamId] " +
                                "INNER JOIN [Stats].[Stadiums] [homeStadium] ON [homeTeam].[StadiumId] = [homeStadium].[Id] " +
                                "INNER JOIN [Stats].[Teams] [awayTeam] ON [awayTeam].[Id] = [match].[AwayTeamId] " +
                                "INNER JOIN [Stats].[Stadiums] [awayStadium] ON [awayTeam].[StadiumId] = [awayStadium].[Id] " +
                                "JOIN [Stats].[Seasons] ON [Seasons].[Id] = (SELECT MAX([Id]) FROM [Stats].[Seasons]) " +
                            "WHERE [DateUtc] BETWEEN [Seasons].[StartUtc] AND [Seasons].[EndUtc]";

            var sqlResult = await _dbConnection.QueryAsync<MatchDataModel, TeamDataModel, StadiumDataModel, TeamDataModel, StadiumDataModel, MatchDataModel>(sql, (match, homeTeam, homeStadium, awayTeam, awayStadium) => {
                match.HomeTeam = homeTeam;
                match.HomeTeam.Stadium = homeStadium;
                match.AwayTeam = awayTeam;
                match.AwayTeam.Stadium = awayStadium;
                return match;
            }, cancellationToken);
            return MatchDataModel.MapOut(sqlResult);
        }

        public async Task<IEnumerable<Match>> FindCurrentMatchday(CancellationToken cancellationToken)
        {
            string sql = "WITH currentMatchday (Matchday) AS " +
                            "(SELECT MAX([match].Matchday) FROM [Stats].[Matches] [match] " +
                            "JOIN [Stats].[Seasons] ON [Seasons].[Id] = (SELECT MAX([Id]) FROM [Stats].[Seasons]) " +
                            "WHERE ([match].HomeTeamScore IS NOT NULL OR [match].AwayTeamScore IS NOT NULL) " +
                            "AND [match].[DateUtc] BETWEEN [Seasons].[StartUtc] AND [Seasons].[EndUtc]) " +
                           "SELECT [match].[Id], [HomeTeamScore], [AwayTeamScore], [Matchday], [DateUtc] AS Date, " +
                                "[homeTeam].[Id], [homeTeam].[Name], [homeStadium].[Id], [homeStadium].[Name], " +
                                "[awayTeam].[Id], [awayTeam].[Name], [awayStadium].[Id], [awayStadium].[Name] " +
                            "FROM [Stats].[Matches] [match] " +
                                "INNER JOIN [Stats].[Teams] [homeTeam] ON [homeTeam].[Id] = [match].[HomeTeamId] " +
                                "INNER JOIN [Stats].[Stadiums] [homeStadium] ON [homeTeam].[StadiumId] = [homeStadium].[Id] " +
                                "INNER JOIN [Stats].[Teams] [awayTeam] ON [awayTeam].[Id] = [match].[AwayTeamId] " +
                                "INNER JOIN [Stats].[Stadiums] [awayStadium] ON [awayTeam].[StadiumId] = [awayStadium].[Id] " +
                                "JOIN [Stats].[Seasons] ON [Seasons].[Id] = (SELECT MAX([Id]) FROM [Stats].[Seasons]) " +
                            $"WHERE [Matchday] IN (SELECT Matchday FROM currentMatchday) AND [DateUtc] BETWEEN [Seasons].[StartUtc] AND [Seasons].[EndUtc]";

            var sqlResult = await _dbConnection.QueryAsync<MatchDataModel, TeamDataModel, StadiumDataModel, TeamDataModel, StadiumDataModel, MatchDataModel>(sql, (match, homeTeam, homeStadium, awayTeam, awayStadium) => {
                match.HomeTeam = homeTeam;
                match.HomeTeam.Stadium = homeStadium;
                match.AwayTeam = awayTeam;
                match.AwayTeam.Stadium = awayStadium;
                return match;
            }, cancellationToken);
            return MatchDataModel.MapOut(sqlResult);
        }

        public async Task<IEnumerable<Match>> FindByMatchday(int matchday, CancellationToken cancellationToken)
        {
            string sql = "SELECT [match].[Id], [HomeTeamScore], [AwayTeamScore], [Matchday], [DateUtc] AS Date, " +
                                "[homeTeam].[Id], [homeTeam].[Name], [homeStadium].[Id], [homeStadium].[Name], " +
                                "[awayTeam].[Id], [awayTeam].[Name], [awayStadium].[Id], [awayStadium].[Name] " +
                            "FROM [Stats].[Matches] [match] " +
                                "INNER JOIN [Stats].[Teams] [homeTeam] ON [homeTeam].[Id] = [match].[HomeTeamId] " +
                                "INNER JOIN [Stats].[Stadiums] [homeStadium] ON [homeTeam].[StadiumId] = [homeStadium].[Id] " +
                                "INNER JOIN [Stats].[Teams] [awayTeam] ON [awayTeam].[Id] = [match].[AwayTeamId] " +
                                "INNER JOIN [Stats].[Stadiums] [awayStadium] ON [awayTeam].[StadiumId] = [awayStadium].[Id] " +
                                "JOIN [Stats].[Seasons] ON [Seasons].[Id] = (SELECT MAX([Id]) FROM [Stats].[Seasons]) " +
                            $"WHERE [Matchday] = {matchday} AND [DateUtc] BETWEEN [Seasons].[StartUtc] AND [Seasons].[EndUtc]";

            var sqlResult = await _dbConnection.QueryAsync<MatchDataModel, TeamDataModel, StadiumDataModel, TeamDataModel, StadiumDataModel, MatchDataModel>(sql, (match, homeTeam, homeStadium, awayTeam, awayStadium) => {
                match.HomeTeam = homeTeam;
                match.HomeTeam.Stadium = homeStadium;
                match.AwayTeam = awayTeam;
                match.AwayTeam.Stadium = awayStadium;
                return match;
            }, cancellationToken);
            return MatchDataModel.MapOut(sqlResult);
        }

        public async Task<bool> Save(Match match, CancellationToken cancellationToken)
        {
            string sql = "INSERT INTO [Stats].[Matches] " +
                "([HomeTeamId] ,[HomeTeamScore] ,[AwayTeamId] ,[AwayTeamScore] ,[Matchday], [DateUtc] ,[CreatedUtc] ,[CreatedBy] ,[ModifiedUtc] ,[ModifiedBy]) " +
                "VALUES " +
                    $"({match.HomeTeam.Id}, {match.Score.Home}, {match.AwayTeam.Id}, {match.Score.Away}, {match.Matchday}, '{match.Date.ToString("yyyy-mm-dd")}', GETDATE(), 'TODO', GETDATE(), 'TODO')";

            var sqlresult = await _dbConnection.ExecuteAsync(sql, cancellationToken);

            return sqlresult == 1;
        }

        public async Task<IEnumerable<Match>> FindByTeamId(long teamId, CancellationToken cancellationToken)
        {
            string sql = "SELECT [match].[Id], [HomeTeamScore], [AwayTeamScore], [Matchday], [DateUtc] AS Date, " +
                                "[homeTeam].[Id], [homeTeam].[Name], [homeStadium].[Id], [homeStadium].[Name], " +
                                "[awayTeam].[Id], [awayTeam].[Name], [awayStadium].[Id], [awayStadium].[Name] " +
                            "FROM [Stats].[Matches] [match] " +
                                "INNER JOIN [Stats].[Teams] [homeTeam] ON [homeTeam].[Id] = [match].[HomeTeamId] " +
                                "INNER JOIN [Stats].[Stadiums] [homeStadium] ON [homeTeam].[StadiumId] = [homeStadium].[Id] " +
                                "INNER JOIN [Stats].[Teams] [awayTeam] ON [awayTeam].[Id] = [match].[AwayTeamId] " +
                                "INNER JOIN [Stats].[Stadiums] [awayStadium] ON [awayTeam].[StadiumId] = [awayStadium].[Id] " +
                                "JOIN [Stats].[Seasons] ON [Seasons].[Id] = (SELECT MAX([Id]) FROM [Stats].[Seasons]) " +
                            $"WHERE ([homeTeam].[Id] = {teamId} OR [awayTeam].[Id] = {teamId}) AND [DateUtc] BETWEEN [Seasons].[StartUtc] AND [Seasons].[EndUtc]";

            var sqlResult = await _dbConnection.QueryAsync<MatchDataModel, TeamDataModel, StadiumDataModel, TeamDataModel, StadiumDataModel, MatchDataModel>(sql, (match, homeTeam, homeStadium, awayTeam, awayStadium) => {
                match.HomeTeam = homeTeam;
                match.HomeTeam.Stadium = homeStadium;
                match.AwayTeam = awayTeam;
                match.AwayTeam.Stadium = awayStadium;
                return match;
            }, cancellationToken);
            return MatchDataModel.MapOut(sqlResult);
        }
    }
}
