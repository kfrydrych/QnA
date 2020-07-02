using MediatR;
using Microsoft.AspNetCore.SignalR;
using QnA.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using QnA.Application.Audience.Commands.PromoteQuestion;
using QnA.Application.Audience.Events;
using QnA.Website.Services;

namespace QnA.Website.Handlers
{
    public class PromoteQuestionOnSessionBoardHandler : INotificationHandler<QuestionPromotedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<ApplicationHub> _context;

        public PromoteQuestionOnSessionBoardHandler(IUnitOfWork unitOfWork, IHubContext<ApplicationHub> context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task Handle(QuestionPromotedEvent notification, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.Questions.FindAsync(notification.QuestionId);

            await _context.Clients.All.SendAsync("PromoteQuestion", new
            {
                Id = question.Id,
                Score = question.Score
            },
            cancellationToken);
        }
    }
}
