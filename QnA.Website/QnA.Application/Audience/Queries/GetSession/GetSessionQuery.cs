using MediatR;
using System;

namespace QnA.Application.Audience.Queries.GetSession
{
    public class GetSessionQuery : IRequest<GetSessionResult>
    {
        public Guid SessionId { get; set; }
    }
}
