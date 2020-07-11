using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Admin.Queries.GetQuestions
{
    public class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, GetQuestionsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetQuestionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetQuestionsResult> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _unitOfWork.Questions
                .AsNoTracking()
                .Where(x => x.Session.Id == request.SessionId).Select(x => new GetQuestionsResult.Question
                {
                    Id = x.Id,
                    Text = x.Text,
                    SessionId = x.Session.Id,
                    Score = x.Score
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