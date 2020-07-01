using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Application.Messages;
using QnA.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Tasks.Commands.PublishNewRegisteredUsers
{
    public class PublishNewRegisteredUserCommand : IRequest
    {
    }

    public class PublishNewRegisteredUserHandler : IRequestHandler<PublishNewRegisteredUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageBroker _broker;
        private readonly IDateService _dateService;

        public PublishNewRegisteredUserHandler(IUnitOfWork unitOfWork, IMessageBroker broker, IDateService dateService)
        {
            _unitOfWork = unitOfWork;
            _broker = broker;
            _dateService = dateService;
        }

        public async Task<Unit> Handle(PublishNewRegisteredUserCommand request, CancellationToken cancellationToken)
        {
            var newRegisteredUserEvent = await _unitOfWork.AuditRecords
                .FirstOrDefaultAsync(x => x.TableName == "Users" &&
                                                    x.Published == false, cancellationToken);

            if (newRegisteredUserEvent != null)
            {
                var userid = Guid.Parse(newRegisteredUserEvent.KeyValues);

                var user = await _unitOfWork.Users
                    .SingleAsync(x => x.Id == userid, cancellationToken);

                var @event = new NewUserRegisteredEvent
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    ApplicationId = 2,
                    EventDate = newRegisteredUserEvent.DateTime
                };

                await _broker.Publish(@event);

                newRegisteredUserEvent.MarkAsPublished(_dateService);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
