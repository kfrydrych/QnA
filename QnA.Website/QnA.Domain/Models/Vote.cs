using QnA.Domain.Interfaces;
using System;

namespace QnA.Domain.Models
{
    public class Vote
    {
        protected Vote()
        {
        }

        public Vote(string addedBy, IDateService dateService)
        {
            DateAdded = dateService.Now;
            AddedBy = addedBy;
        }

        public Guid Id { get; protected set; }
        public Question Question { get; protected set; }
        public DateTime DateAdded { get; protected set; }
        public string AddedBy { get; protected set; }

    }
}
