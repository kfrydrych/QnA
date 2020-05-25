using QnA.Domain.Exceptions;
using QnA.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QnA.Domain.Models
{
    public class Question
    {
        private readonly List<Vote> _votes;

        protected Question()
        {
        }

        public Question(Session session, string text, string createdBy, IDateService dateService)
        {
            Session = session;
            Text = text;
            Score = 0;
            DateAdded = dateService.Now;
            CreatedBy = createdBy;
            _votes = new List<Vote>();
        }

        public Guid Id { get; protected set; }
        public Session Session { get; protected set; }
        public string Text { get; protected set; }
        public int Score { get; protected set; }
        public DateTime DateAdded { get; protected set; }
        public string CreatedBy { get; protected set; }
        public IReadOnlyList<Vote> Votes => _votes;

        public void Promote(string promotedBy, IDateService dateService)
        {
            if (Votes.Any(x => x.AddedBy == promotedBy))
                throw new DomainException(typeof(Question), "You already promoted this question");

            _votes.Add(new Vote(promotedBy, dateService));
            Score++;
        }
    }
}