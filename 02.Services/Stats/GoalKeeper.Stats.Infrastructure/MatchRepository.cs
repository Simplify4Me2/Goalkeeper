using Dapper;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.ValueObjects;
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

        public async Task<IEnumerable<PlayedMatch>> GetResults(CancellationToken cancellationToken)
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

        public Task<IEnumerable<Fixture>> GetFixtures(int matchday, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Save(PlayedMatch match, CancellationToken cancellationToken)
        {
            string sql = "INSERT INTO [Stats].[Matches] " +
                "([HomeTeamId] ,[HomeTeamScore] ,[AwayTeamId] ,[AwayTeamScore] ,[Matchday], [DateUtc] ,[CreatedUtc] ,[CreatedBy] ,[ModifiedUtc] ,[ModifiedBy]) " +
                "VALUES " +
                    $"({match.HomeTeam.Id}, {match.FinalScore.Home}, {match.AwayTeam.Id}, {match.FinalScore.Away}, {match.Matchday}, '{match.Date.ToString("yyyy-mm-dd")}', GETDATE(), 'TODO', GETDATE(), 'TODO')";

            var sqlresult = await _dbConnection.ExecuteAsync(sql, cancellationToken);

            return sqlresult == 1;
        }
    }
}
