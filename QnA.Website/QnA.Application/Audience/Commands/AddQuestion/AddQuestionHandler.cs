using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QnA.Application.Audience.Events;
using QnA.Application.Interfaces;
using QnA.Domain.Exceptions;
using QnA.Domain.Interfaces;

namespace QnA.Application.Audience.Commands.AddQuestion
{
    public class AddQuestionHandler : IRequestHandler<AddQuestionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateService _dateService;
        private readonly IMediator _mediator;
        private readonly IUser _user;

        public AddQuestionHandler(IUnitOfWork unitOfWork, IDateService dateService, IMediator mediator, IUser user)
        {
            _unitOfWork = unitOfWork;
            _dateService = dateService;
            _mediator = mediator;
            _user = user;
        }

        public async Task<Unit> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var session = await _unitOfWork.Sessions.FindAsync(request.SessionId);

            if (session == null)
                throw new NotFoundException(typeof(AddQuestionHandler), "Session not found");

            var questionAdded = session.AddQuestion(request.Text, _user.UniqueSource, _dateService);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new QuestionAddedEvent { QuestionId = questionAdded.Id }, cancellationToken);

            return Unit.Value;
        }
    }
}