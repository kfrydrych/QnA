using MediatR;

namespace QnA.Application.Users.Events
{
    public class UserLoggedInEvent : INotification
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
