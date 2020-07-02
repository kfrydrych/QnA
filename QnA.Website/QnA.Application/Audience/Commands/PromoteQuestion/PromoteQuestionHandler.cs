using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Domain.Exceptions;
using QnA.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using QnA.Application.Audience.Events;

namespace QnA.Application.Audience.Commands.PromoteQuestion
{
    public class PromoteQuestionHandler : IRequestHandler<PromoteQuestionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateService _dateService;
        private readonly IMediator _mediator;
        private readonly IUser _user;

        public PromoteQuestionHandler(IUnitOfWork unitOfWork, IDateService dateService, IMediator mediator, IUser user)
        {
            _unitOfWork = unitOfWork;
            _dateService = dateService;
            _mediator = mediator;
            _user = user;
        }

        public async Task<Unit> Handle(PromoteQuestionCommand request, CancellationToken cancellationToken)
        {
            var session = await _unitOfWork.Sessions
                .Include(x => x.Questions)
                .ThenInclude(x => x.Votes)
                .SingleOrDefaultAsync(x => x.Id == request.SessionId, cancellationToken);

            if (session == null)
                throw new NotFoundException(typeof(PromoteQuestionHandler), "Session not found");

            var promotedQuestion = session.PromoteQuestion(request.QuestionId, _user.UniqueSource, _dateService);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new QuestionPromotedEvent { QuestionId = promotedQuestion.Id }, cancellationToken);

            return Unit.Value;
        }
    }
}