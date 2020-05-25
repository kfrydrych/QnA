using FluentValidation;

namespace QnA.Application.Admin.Queries.GetQuestions
{
    public class GetQuestionsValidator : AbstractValidator<GetQuestionsQuery>
    {
        public GetQuestionsValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}