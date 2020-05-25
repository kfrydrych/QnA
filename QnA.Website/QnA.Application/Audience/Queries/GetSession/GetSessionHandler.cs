using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Audience.Commands.AddQuestion;
using QnA.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Audience.Queries.GetSession
{
    public class GetSessionHandler : IRequestHandler<GetSessionQuery, GetSessionResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSessionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSessionResult> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Sessions
                .Where(x => x.Id == request.SessionId)
                .Select(x => new GetSessionResult
                {
                    SessionId = x.Id,
                    Title = x.Title,
                    AddQuestionCommand = new AddQuestionCommand
                    {
                        SessionId = x.Id
                    }
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}