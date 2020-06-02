using QnA.Domain.Interfaces;
using System;

namespace QnA.Domain.Common
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; protected set; }

        public DateTime Created { get; protected set; }

        public string LastModifiedBy { get; protected set; }

        public DateTime? LastModified { get; protected set; }

        public string LastChangeEvent { get; protected set; }

        protected void CaptureCreation(string createdBy, IDateService dateService)
        {
            CreatedBy = createdBy;
            Created = dateService.Now;
            LastChangeEvent = "Created";
        }

        protected void CaptureModification(string lastModifiedBy, IDateService dateService, string message = null)
        {
            LastModifiedBy = lastModifiedBy;
            LastModified = dateService.Now;
            LastChangeEvent = message ?? "Modified";
        }
    }
}
