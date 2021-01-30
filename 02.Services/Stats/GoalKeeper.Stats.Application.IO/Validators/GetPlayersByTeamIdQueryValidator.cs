using FluentValidation;
using GoalKeeper.Stats.Application.IO.Queries;

namespace GoalKeeper.Stats.Application.IO.Validators
{
    // TODO: refactor to IPipelineBehavior
    // https://timdows.com/projects/use-mediatr-with-fluentvalidation-in-the-asp-net-core-pipeline/
    public class GetPlayersByTeamIdQueryValidator : AbstractValidator<GetPlayersByTeamIdQuery>
    {
        public GetPlayersByTeamIdQueryValidator()
        {
            RuleFor(q => q.Id).NotEqual(0);
        }
    }
}
