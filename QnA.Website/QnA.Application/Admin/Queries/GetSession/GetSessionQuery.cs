using MediatR;
using QnA.Application.Admin.Queries.GetSessions;
using System;

namespace QnA.Application.Admin.Queries.GetSession
{
    public class GetSessionQuery : IRequest<GetSessionsResult.Session>
    {
        public Guid SessionId { get; set; }
    }
}
