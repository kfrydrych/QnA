using MediatR;
using QnA.Application.Interfaces;
using QnA.Application.Users.Events;
using QnA.Domain.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Users.Handlers
{
    public class RegisterNewUserHandler : INotificationHandler<UserLoggedInEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterNewUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UserLoggedInEvent notification, CancellationToken cancellationToken)
        {
            var userExist = _unitOfWork.Users.Any(x => x.Email == notification.Email);

            if (!userExist)
            {
                var user = new ApplicationUser(notification.FullName, notification.Email);
                _unitOfWork.Users.Add(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}