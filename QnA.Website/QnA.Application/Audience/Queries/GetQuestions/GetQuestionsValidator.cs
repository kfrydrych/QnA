using FluentValidation;

namespace QnA.Application.Audience.Queries.GetQuestions
{
    public class GetQuestionsValidator : AbstractValidator<GetQuestionsQuery>
    {
        public GetQuestionsValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}