using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using GoalKeeper.Stats.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetRankingQueryHandler : IRequestHandler<GetRankingQuery, RankingDTO>
    {
        private readonly IStatsRepository _repository;

        public GetRankingQueryHandler(IStatsRepository repository)
        {
            _repository = repository;
        }

        public async Task<RankingDTO> Handle(GetRankingQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetRanking(cancellationToken);

            var matches = await _repository.GetMatches(cancellationToken);

            var teams = await _repository.GetTeams(cancellationToken);

            var teamRankings = new List<TeamRanking>();
            foreach (Team team in teams)
            {
                int points = 0;
                var homeMatches = matches.Where(match => match.HomeTeam.Id == team.Id);
                foreach (var match in homeMatches)
                {
                    if (match.HomeTeamScore > match.AwayTeamScore) points += 3;
                    if (match.HomeTeamScore == match.AwayTeamScore) points += 1;
                };

                var awayMatches = matches.Where(match => match.AwayTeam.Id == team.Id);
                foreach (var match in homeMatches)
                {
                    if (match.HomeTeamScore > match.AwayTeamScore) points += 3;
                    if (match.HomeTeamScore == match.AwayTeamScore) points += 1;
                };

                var teamRanking = new TeamRanking
                {
                    Team = team,
                    Points = points
                };

                teamRankings.Add(teamRanking);
            };

            var ranking = new Ranking
            {
                Name = data.Name,
                TeamRankings = teamRankings.OrderByDescending(teamRanking => teamRanking.Points).ToList()
            };

            return ranking.MapOut();
        }
    }
}
