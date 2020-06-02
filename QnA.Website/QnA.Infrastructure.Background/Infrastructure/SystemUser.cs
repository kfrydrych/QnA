using QnA.Application.Interfaces;

namespace QnA.Infrastructure.Background.Infrastructure
{
    public class SystemUser : IUser
    {
        public string Username => "SYSTEM";
        public string UniqueSource => "SYSTEM";
    }
}
