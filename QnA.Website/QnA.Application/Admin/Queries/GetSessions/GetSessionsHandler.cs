using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Domain.Models;
using System.Collections.Generic;
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
                .Take(request.Limit)
                .Select(x => new GetSessionsResult.Session
                {
                    Id = x.Id.ToString(),
                    Title = x.Title,
                    Status = x.Status,
                    StatusName = x.Status.ToString(),
                    DateCreated = x.Created.ToShortDateString()
                })
                .ToListAsync(cancellationToken);

            var totalCount = _unitOfWork.Sessions.Count(x => x.CreatedBy == _user.Username);

            var statistics = new GetSessionsResult.Stats
            {
                DisplayCount = sessions.Count,
                TotalCount = totalCount,
                OnlineCount = _unitOfWork.Sessions.Count(x => x.CreatedBy == _user.Username && x.Status == Status.Online),
                OfflineCount = _unitOfWork.Sessions.Count(x => x.CreatedBy == _user.Username && x.Status == Status.Offline),
                ArchivedCount = _unitOfWork.Sessions.Count(x => x.CreatedBy == _user.Username && x.Status == Status.Archived)
            };

            return new GetSessionsResult
            {
                Sessions = sessions,
                Statistics = statistics,
                LimitOptions = GetLimitOptions(totalCount)
            };
        }

        private List<int> GetLimitOptions(int totalCount)
        {
            var listOptions = new List<int> { 10, 20, 50, 100, 200, 500 };
            var highestValue = listOptions.Max();
            if (totalCount > highestValue)
                listOptions.Add(totalCount);

            return listOptions;
        }
    }
}