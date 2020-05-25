using QnA.Domain.Exceptions;
using QnA.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QnA.Domain.Models
{
    public class Session
    {
        protected Session()
        {
        }

        public Session(string title, string accessCode, string owner, IDateService dateService)
        {
            Status = Status.Online;
            Title = title;
            AccessCode = accessCode;
            Owner = owner;
            DateCreated = dateService.Now;
        }

        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string AccessCode { get; protected set; }
        public Status Status { get; protected set; }
        public string Owner { get; protected set; }
        public DateTime DateCreated { get; protected set; }
        public IList<Question> Questions { get; set; } = new List<Question>();

        public Question AddQuestion(string text, string createdBy, IDateService dateService)
        {
            if (Status == Status.Offline)
                throw new DomainException(typeof(Session), "Session is offline");

            var question = new Question(this, text, createdBy, dateService);

            Questions.Add(question);

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
        public void SetOnline()
        {
            Status = Status.Online;
        }
        public void SetOffline()
        {
            Status = Status.Offline;
        }
    }

    public enum Status
    {
        Online = 1,
        Offline = 2
    }
}
