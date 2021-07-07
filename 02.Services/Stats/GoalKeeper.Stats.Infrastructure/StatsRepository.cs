using Dapper;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
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

        public Task<League> GetRanking(CancellationToken cancellationToken)
        {
            //var ranking = _eventStore.AggregateStream<Ranking>(1);

            //var foo = new EventSourcingRepository();
            //await foo.SaveAsync(new Guid());

            //string sql = "SELECT [Id], [Name] FROM [Stats].[Teams]";

            //var result = await _dbConnection.QueryAsync<Team>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            //var random = new Random();
            //Ranking ranking = new Ranking
            //{
            //    Name = "Jupiler Pro League",
            //    //TeamRankings = result.Select(team => new TeamRanking
            //    //{
            //    //    //Id = team.Id,
            //    //    Team = team,
            //    //    Points = random.Next(36, 76)
            //    //}).ToList()
            //    //Teams = result.ToList()
            //};

            //return Task.Run(() => ranking);

            throw new NotImplementedException();
        }

        public async Task<Team> GetTeamById(long id, CancellationToken cancellationToken)
        {
            string sql = $"SELECT [Teams].[Id], [Teams].[Name], [Players].[Id], [Players].[TeamId], [Players].[FirstName], [Players].[LastName], [Players].[ShirtNumber], [Players].[Position] " +
                $"FROM [Stats].[Players] " +
                    $"INNER JOIN [Stats].[Teams] ON [Teams].[Id] = [Players].[TeamId] " +
                $"WHERE [Teams].[Id] = {id}";

            var sqlResult = await _dbConnection.QueryAsync<TeamDataModel, Player, TeamDataModel>(sql, (team, player) =>
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

            var sqlResult = await _dbConnection.QueryAsync<TeamDataModel, Player, TeamDataModel>(sql, (team, player) =>
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
            string sql = "SELECT [Id], [Name] FROM [Stats].[Teams]";

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

        public async Task<IEnumerable<Match>> GetMatches(CancellationToken cancellationToken)
        {
            string sql =    "SELECT [match].[Id], [HomeTeamScore], [AwayTeamScore], [Matchday], [DateUtc] AS Date, " +
                                "[homeTeam].[Id], [homeTeam].[Name], " +
                                "[awayTeam].[Id], [awayTeam].[Name] " +
                            "FROM [Stats].[Matches] [match] " +
                                "INNER JOIN [Stats].[Teams] [homeTeam] ON [homeTeam].[Id] = [match].[HomeTeamId] " +
                                "INNER JOIN [Stats].[Teams] [awayTeam] ON [awayTeam].[Id] = [match].[AwayTeamId]";

            var sqlResult = await _dbConnection.QueryAsync<MatchDataModel, TeamDataModel, TeamDataModel, MatchDataModel>(sql, (match, homeTeam, awayTeam) => {
                match.HomeTeam = homeTeam;
                match.AwayTeam = awayTeam;
                return match;
            }, cancellationToken);
            return MatchDataModel.MapOut(sqlResult);
        }
    }
}
