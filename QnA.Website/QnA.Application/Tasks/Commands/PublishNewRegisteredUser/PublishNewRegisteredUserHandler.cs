using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Application.Messages;
using QnA.Domain.Definitions;
using QnA.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Tasks.Commands.PublishNewRegisteredUser
{
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
                .FirstOrDefaultAsync(x => x.TableName == AuditRecordTable.Users &&
                                          x.Published == false, cancellationToken);

            if (newRegisteredUserEvent != null)
            {
                var user = await _unitOfWork.Users
                    .SingleAsync(x => x.Id == newRegisteredUserEvent.SubjectId, cancellationToken);

                var @event = new NewUserRegisteredEvent
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    ApplicationId = ApplicationId.QnA,
                    EventDate = newRegisteredUserEvent.DateTime
                };

                newRegisteredUserEvent.MarkAsPublished(_dateService);

                await _broker.Publish(@event);

                await _unitOfWork.SaveChangesWithoutHistoryAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}