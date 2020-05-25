using FluentValidation;

namespace QnA.Application.Audience.Commands.PromoteQuestion
{
    public class PromoteQuestionValidator : AbstractValidator<PromoteQuestionCommand>
    {
        public PromoteQuestionValidator()
        {
            RuleFor(x => x.QuestionId).NotEmpty();
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}