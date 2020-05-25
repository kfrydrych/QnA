using FluentValidation;

namespace QnA.Application.Admin.Commands.SetSessionOnline
{
    public class SetSessionOnlineValidator : AbstractValidator<SetSessionOnlineCommand>
    {
        public SetSessionOnlineValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}