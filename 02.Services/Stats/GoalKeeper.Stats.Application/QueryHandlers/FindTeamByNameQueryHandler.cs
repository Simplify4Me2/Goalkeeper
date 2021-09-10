using FluentValidation;
using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.IO.Validators;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class FindTeamByNameQueryHandler : IRequestHandler<FindTeamByNameQuery, TeamDTO>
    {
        private readonly IStatsRepository _repository;
        private readonly IMatchRepository _matchRepository;
        private readonly GetTeamByNameQueryValidator validator;

        public FindTeamByNameQueryHandler(IStatsRepository repository, IMatchRepository matchRepository)
        {
            _repository = repository;
            _matchRepository = matchRepository;
            validator = new GetTeamByNameQueryValidator();
        }

        public async Task<TeamDTO> Handle(FindTeamByNameQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var team = await _repository.GetTeamByName(request.Name, cancellationToken);
            var matches = await _matchRepository.FindByTeamId(team.Id, cancellationToken);

            TeamDTO returnValue = team.MapOut();
            returnValue.Form = team.FormToString(matches.ToList());
            return returnValue;
        }
    }
}
