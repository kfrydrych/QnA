using FluentValidation;

namespace QnA.Application.Audience.Queries.GetSession
{
    public class GetSessionValidator : AbstractValidator<GetSessionQuery>
    {
        public GetSessionValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}