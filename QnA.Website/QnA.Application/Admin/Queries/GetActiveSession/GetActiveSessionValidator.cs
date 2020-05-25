using FluentValidation;

namespace QnA.Application.Admin.Queries.GetActiveSession
{
    public class GetActiveSessionValidator : AbstractValidator<GetActiveSessionQuery>
    {
        public GetActiveSessionValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}