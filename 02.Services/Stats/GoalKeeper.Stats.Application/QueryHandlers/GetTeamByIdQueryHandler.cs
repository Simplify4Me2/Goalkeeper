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
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, TeamDTO>
    {
        private readonly IStatsRepository _repository;
        private readonly GetTeamByIdQueryValidator validator;

        public GetTeamByIdQueryHandler(IStatsRepository repository)
        {
            _repository = repository;
            validator = new GetTeamByIdQueryValidator();
        }

        public async Task<TeamDTO> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var data = await _repository.GetTeamById(request.Id, cancellationToken);

            return data.MapOut();
        }
    }
}
