using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Audience.Queries.GetQuestions
{
    public class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, GetQuestionsResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUser _user;

        public GetQuestionsHandler(IUnitOfWork unitOfWork, IUser user)
        {
            _unitOfWork = unitOfWork;
            _user = user;
        }

        public async Task<GetQuestionsResult> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _unitOfWork.Questions
                .AsNoTracking()
                .Where(x => x.Session.Id == request.SessionId)
                .Select(x => new GetQuestionsResult.Question
                {
                    Id = x.Id,
                    Text = x.Text,
                    SessionId = x.Session.Id,
                    Score = x.Score,
                    CanVote = x.CreatedBy != _user.UniqueSource,
                    NotAlreadyVoted = x.Votes.Count(v => v.CreatedBy == _user.UniqueSource) == 0,
                    IsCreatedByUser = x.CreatedBy == _user.UniqueSource
                })
                .OrderByDescending(x => x.Score)
                .ToListAsync(cancellationToken);

            return new GetQuestionsResult
            {
                Questions = questions
            };
        }
    }
}