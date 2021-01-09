using FluentValidation;
using GoalKeeper.Stats.Application.IO.Queries;

namespace GoalKeeper.Stats.Application.IO.Validators
{
    public class GetTeamByIdQueryValidator : AbstractValidator<GetTeamByIdQuery>
    {
        public GetTeamByIdQueryValidator()
        {
            RuleFor(q => q.Id).NotNull();
            RuleFor(q => q.Id).NotEqual(0);
        }
    }
}
