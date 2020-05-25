using QnA.Domain.Models;
using System.Collections.Generic;

namespace QnA.Application.Admin.Queries.GetSessions
{
    public class GetSessionsResult
    {
        public IReadOnlyList<Session> Sessions { get; set; }

        public class Session
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public Status Status { get; set; }
            public string StatusName { get; set; }
            public string DateCreated { get; set; }
            public bool CanSetOffline => Status == Status.Online;
            public bool CanSetOnline => Status == Status.Offline;
        }
    }
}