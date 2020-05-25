using FluentValidation;

namespace QnA.Application.Admin.Commands.CreateSession
{
    public class CreateSessionValidator : AbstractValidator<CreateSessionCommand>
    {
        public CreateSessionValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.AccessCode).NotEmpty();
        }
    }
}