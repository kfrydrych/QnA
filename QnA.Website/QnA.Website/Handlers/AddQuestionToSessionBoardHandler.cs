using MediatR;
using Microsoft.AspNetCore.SignalR;
using QnA.Application.Audience.Events;
using QnA.Application.Interfaces;
using QnA.Website.Services;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Website.Handlers
{
    public class AddQuestionToSessionBoardHandler : INotificationHandler<QuestionAddedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<ApplicationHub> _context;

        public AddQuestionToSessionBoardHandler(IUnitOfWork unitOfWork, IHubContext<ApplicationHub> context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task Handle(QuestionAddedEvent notification, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.Questions.FindAsync(notification.QuestionId);

            await _context.Clients.All.SendAsync("AddQuestion", new
            {
                Id = question.Id,
                Text = question.Text,
                SessionId = question.Session.Id,
                Score = question.Score
            },
            cancellationToken);
        }
    }
}
