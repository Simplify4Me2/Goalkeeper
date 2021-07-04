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
                teamRankings.Add(Ranking.CalculatePoints(team, matches.Where(match => match.HomeTeam.Id == team.Id || match.AwayTeam.Id == team.Id).ToList()));

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
