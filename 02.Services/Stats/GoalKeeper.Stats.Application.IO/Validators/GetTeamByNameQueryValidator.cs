using FluentValidation;
using GoalKeeper.Stats.Application.IO.Queries;

namespace GoalKeeper.Stats.Application.IO.Validators
{
    // TODO: refactor to IPipelineBehavior
    // https://timdows.com/projects/use-mediatr-with-fluentvalidation-in-the-asp-net-core-pipeline/
    public class GetTeamByNameQueryValidator : AbstractValidator<FindTeamByNameQuery>
    {
        public GetTeamByNameQueryValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }
}
