using System;
using MediatR;

namespace QnA.Application.Admin.Queries.GetActiveSession
{
    public class GetActiveSessionQuery : IRequest<GetActiveSessionResult>
    {
        public Guid SessionId { get; set; }
    }
}
