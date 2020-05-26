using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Admin.Queries.GetActiveSession
{
    public class GetActiveSessionHandler : IRequestHandler<GetActiveSessionQuery, GetActiveSessionResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActiveSessionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetActiveSessionResult> Handle(GetActiveSessionQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Sessions.Where(x => x.Id == request.SessionId)
                .Select(x => new GetActiveSessionResult
                {
                    Title = x.Title,
                    Password = x.AccessCode,
                    IsOffline = x.Status == Status.Offline
                })
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}