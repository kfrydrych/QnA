using MediatR;

namespace QnA.Application.Audience.Queries.FindSessions
{
    public class FindSessionsQuery : IRequest<FindSessionsResult>
    {
        public string AccessCode { get; set; }
    }
}
