using MediatR;
using System;

namespace QnA.Application.Admin.Queries.GetSessions
{
    public class GetSessionsQuery : IRequest<GetSessionsResult>
    {
        private readonly int _defaultLimit = 10;
        public GetSessionsQuery()
        {
            Limit = _defaultLimit;
        }

        public GetSessionsQuery(int? limit)
        {
            Limit = limit != null ? Convert.ToInt16(limit) : _defaultLimit;
        }

        public int Limit { get; protected set; }
    }
}
