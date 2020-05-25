using FluentValidation;

namespace QnA.Application.Audience.Queries.FindSessions
{
    public class FindSessionsValidator : AbstractValidator<FindSessionsQuery>
    {
        public FindSessionsValidator()
        {
            RuleFor(x => x.AccessCode).NotEmpty();
        }
    }
}