using QnA.Domain.Common;
using QnA.Domain.Interfaces;
using System;

namespace QnA.Domain.Models
{
    public class Vote : AuditableEntity
    {
        protected Vote()
        {
        }

        public Vote(string createdBy, IDateService dateService)
        {
            CaptureCreation(createdBy, dateService);
        }

        public Guid Id { get; protected set; }
        public Question Question { get; protected set; }
        public Guid QuestionId { get; protected set; }
    }
}
