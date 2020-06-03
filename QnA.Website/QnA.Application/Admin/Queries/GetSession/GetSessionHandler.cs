using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Admin.Queries.GetSessions;
using QnA.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Admin.Queries.GetSession
{
    public class GetSessionHandler : IRequestHandler<GetSessionQuery, GetSessionsResult.Session>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSessionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSessionsResult.Session> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Sessions
                .Where(x => x.Id == request.SessionId)
                .OrderByDescending(x => x.Created)
                .Select(x => new GetSessionsResult.Session
                {
                    Id = x.Id.ToString(),
                    Title = x.Title,
                    Status = x.Status,
                    StatusName = x.Status.ToString(),
                    DateCreated = x.Created.ToShortDateString()
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
