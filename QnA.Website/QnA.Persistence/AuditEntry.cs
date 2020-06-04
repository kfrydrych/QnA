using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using QnA.Application.Interfaces;
using QnA.Domain.Common;
using QnA.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QnA.Persistence
{
    public class AuditEntry
    {
        private readonly IUser _user;
        private readonly IDateService _dateService;
        public AuditEntry(EntityEntry entry, IUser user, IDateService dateService)
        {
            Entry = entry;
            _user = user;
            _dateService = dateService;
        }

        public EntityEntry Entry { get; }
        public string TableName { get; set; }
        public string EventMessage { get; set; }
        public object SubjectId { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditRecord ToAudit()
        {
            var audit = new AuditRecord
            {
                TableName = TableName,
                EventMessage = EventMessage,
                DateTime = _dateService.Now,
                SubjectId = (Guid)SubjectId,
                KeyValues = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
                ModifiedBy = _user.Username ?? _user.UniqueSource
            };
            return audit;
        }
    }
}
