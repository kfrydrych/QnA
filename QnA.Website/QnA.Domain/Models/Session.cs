using QnA.Domain.Common;
using QnA.Domain.Exceptions;
using QnA.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QnA.Domain.Models
{
    public class Session : AuditableEntity
    {
        protected Session()
        {
        }

        public Session(string title, string accessCode, string createdBy, IDateService dateService)
        {
            Status = Status.Online;
            Title = title;
            AccessCode = accessCode;
            CaptureCreation(createdBy, dateService);
        }

        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string AccessCode { get; protected set; }
        public Status Status { get; protected set; }
        public IList<Question> Questions { get; set; } = new List<Question>();

        public Question AddQuestion(string text, string createdBy, IDateService dateService)
        {
            if (Status == Status.Offline)
                throw new DomainException(typeof(Session), "Session is offline");

            var question = new Question(this, text, createdBy, dateService);

            Questions.Add(question);

            CaptureModification(createdBy, dateService, "Question added");

            return question;
        }
        public Question PromoteQuestion(Guid questionId, string promotedBy, IDateService dateService)
        {
            if (Status == Status.Offline)
                throw new DomainException(typeof(Session), "Session is offline");

            var question = Questions
                .SingleOrDefault(x => x.Id == questionId);

            if (question == null)
                throw new DomainException(typeof(Session), "Question not found");

            question.Promote(promotedBy, dateService);

            return question;
        }
        public void SetOnline(string createdBy, IDateService dateService)
        {
            Status = Status.Online;
            CaptureModification(createdBy, dateService, $"Set {nameof(Status.Online)}");
        }
        public void SetOffline(string createdBy, IDateService dateService)
        {
            Status = Status.Offline;
            CaptureModification(createdBy, dateService, $"Set {nameof(Status.Offline)}");
        }

        public void Archive(string createdBy, IDateService dateService)
        {
            Status = Status.Archived;
            CaptureModification(createdBy, dateService, $"{nameof(Status.Archived)}");
        }
    }

    public enum Status
    {
        Online = 1,
        Offline = 2,
        Archived = 3
    }
}
