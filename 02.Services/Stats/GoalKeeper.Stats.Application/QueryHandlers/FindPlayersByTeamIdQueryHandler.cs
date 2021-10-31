using FluentValidation;
using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using GoalKeeper.Stats.Application.IO.Validators;
using GoalKeeper.Stats.Application.Ports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GoalKeeper.Stats.Application.Mappers;

namespace GoalKeeper.Stats.Application.QueryHandlers
{
    public class FindPlayersByTeamIdQueryHandler : IRequestHandler<FindPlayersByTeamIdQuery, IEnumerable<PlayerDTO>>
    {
        private readonly IStatsRepository _repository;
        private readonly GetPlayersByTeamIdQueryValidator validator;

        public FindPlayersByTeamIdQueryHandler(IStatsRepository repository)
        {
            _repository = repository;
            validator = new GetPlayersByTeamIdQueryValidator();
        }

        public async Task<IEnumerable<PlayerDTO>> Handle(FindPlayersByTeamIdQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var data = await _repository.GetPlayersByTeamId(request.Id, cancellationToken);

            return data.MapOut();
        }
    }
}
