using FluentValidation;

namespace QnA.Application.Admin.Commands.SetSessionOffline
{
    public class SetSessionOfflineValidator : AbstractValidator<SetSessionOfflineCommand>
    {
        public SetSessionOfflineValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
        }
    }
}