using FluentValidation;

namespace QnA.Application.Admin.Commands.CreateSession
{
    public class CreateSessionValidator : AbstractValidator<CreateSessionCommand>
    {
        public CreateSessionValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
            RuleFor(x => x.AccessCode).NotEmpty().MaximumLength(50);
        }
    }
}