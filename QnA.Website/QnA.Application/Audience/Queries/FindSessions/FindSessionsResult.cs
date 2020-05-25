using System.Collections.Generic;

namespace QnA.Application.Audience.Queries.FindSessions
{
    public class FindSessionsResult
    {
        public IReadOnlyList<Session> Sessions { get; set; }

        public class Session
        {
            public string Id { get; set; }
            public string Title { get; set; }
        }
    }
}