using QnA.Domain.Models;
using System.Collections.Generic;

namespace QnA.Application.Admin.Queries.GetSessions
{
    public class GetSessionsResult
    {
        public int Limit { get; set; }
        public IEnumerable<int> LimitOptions { get; set; }
        public Stats Statistics { get; set; }
        public IReadOnlyList<Session> Sessions { get; set; }
        public class Stats
        {
            public int DisplayCount { get; set; }
            public int TotalCount { get; set; }
            public int OnlineCount { get; set; }
            public int OfflineCount { get; set; }
            public int ArchivedCount { get; set; }
        }
        public class Session
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public Status Status { get; set; }
            public string StatusName { get; set; }
            public string DateCreated { get; set; }
            public bool IsOnline => Status == Status.Online;
            public bool IsOffline => Status == Status.Offline;
        }
    }
}