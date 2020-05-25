using FluentValidation;
using QnA.Application.Interfaces;
using System.Linq;

namespace QnA.Application.Audience.Commands.AddQuestion
{
    public class AddQuestionValidator : AbstractValidator<AddQuestionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddQuestionValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.SessionId).NotEmpty();
            RuleFor(x => x)
                .Must(x => !QuestionDuplicated(x))
                .WithMessage("This question already exist");
        }

        private bool QuestionDuplicated(AddQuestionCommand command)
        {
            return _unitOfWork.Questions.Any(x => x.Session.Id == command.SessionId && x.Text == command.Text);
        }
    }
}