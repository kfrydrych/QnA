using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Audience.Queries.FindSessions
{
    public class FindSessionsHandler : IRequestHandler<FindSessionsQuery, FindSessionsResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FindSessionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FindSessionsResult> Handle(FindSessionsQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _unitOfWork.Sessions
                .AsNoTracking()
                .Where(x => x.AccessCode == request.AccessCode && x.Status == Status.Online)
                .Select(x => new FindSessionsResult.Session
                {
                    Id = x.Id.ToString(),
                    Title = x.Title
                })
                .ToListAsync(cancellationToken);

            return new FindSessionsResult
            {
                Sessions = sessions
            };
        }
    }
}