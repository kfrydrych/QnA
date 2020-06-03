using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Admin.Queries.GetSessions
{
    public class GetSessionsHandler : IRequestHandler<GetSessionsQuery, GetSessionsResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUser _user;

        public GetSessionsHandler(IUnitOfWork unitOfWork, IUser user)
        {
            _unitOfWork = unitOfWork;
            _user = user;
        }

        public async Task<GetSessionsResult> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _unitOfWork.Sessions
                .Where(x => x.CreatedBy == _user.Username)
                .OrderByDescending(x => x.Created)
                .Select(x => new GetSessionsResult.Session
                {
                    Id = x.Id.ToString(),
                    Title = x.Title,
                    Status = x.Status,
                    StatusName = x.Status.ToString(),
                    DateCreated = x.Created.ToShortDateString()
                })
                .ToListAsync(cancellationToken);

            return new GetSessionsResult
            {
                Sessions = sessions
            };
        }
    }
}