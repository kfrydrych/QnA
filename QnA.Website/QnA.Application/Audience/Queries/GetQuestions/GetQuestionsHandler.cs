using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Domain.Exceptions;
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
            var session = await _unitOfWork.Sessions
                .Include(x => x.Questions)
                .ThenInclude(x => x.Votes)
                .SingleOrDefaultAsync(x => x.Id == request.SessionId, cancellationToken);

            if (session == null)
                throw new NotFoundException(typeof(GetQuestionsHandler), "Session not found");

            var questions = session.Questions.Select(x => new GetQuestionsResult.Question
            {
                Id = x.Id,
                Text = x.Text,
                SessionId = session.Id,
                Score = x.Score,
                CanVote = x.CreatedBy != _user.UniqueSource,
                NotAlreadyVoted = x.Votes.Count(v => v.CreatedBy == _user.UniqueSource) == 0,
                IsCreatedByUser = x.CreatedBy == _user.UniqueSource
            })
            .OrderByDescending(x => x.Score)
            .ToList();

            return new GetQuestionsResult
            {
                Questions = questions
            };
        }
    }
}