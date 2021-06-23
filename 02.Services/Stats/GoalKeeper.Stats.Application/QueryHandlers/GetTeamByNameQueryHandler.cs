using FluentValidation;
using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.IO.Validators;
using GoalKeeper.Stats.Application.Mappers;
using GoalKeeper.Stats.Application.Ports;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class GetTeamByNameQueryHandler : IRequestHandler<GetTeamByNameQuery, TeamDTO>
    {
        private readonly IStatsRepository _repository;
        private readonly GetTeamByNameQueryValidator validator;

        public GetTeamByNameQueryHandler(IStatsRepository repository)
        {
            _repository = repository;
            validator = new GetTeamByNameQueryValidator();
        }

        public async Task<TeamDTO> Handle(GetTeamByNameQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var data = await _repository.GetTeamByName(request.Name, cancellationToken);

            return data.MapOut();
        }
    }
}
