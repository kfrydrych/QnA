using QnA.Domain.Interfaces;
using System;

namespace QnA.Domain.Common
{
    public class AuditRecord
    {
        public long Id { get; set; }
        public string TableName { get; set; }
        public string EventMessage { get; set; }
        public DateTime DateTime { get; set; }
        public Guid SubjectId { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string ModifiedBy { get; set; }
        public bool Published { get; protected set; }
        public DateTime? PublishDateTime { get; protected set; }

        public void MarkAsPublished(IDateService dateService)
        {
            Published = true;
            PublishDateTime = dateService.Now;
        }
    }
}
