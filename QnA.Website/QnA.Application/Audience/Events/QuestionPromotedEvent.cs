using System;
using MediatR;

namespace QnA.Application.Audience.Events
{
    public class QuestionPromotedEvent : INotification
    {
        public Guid QuestionId { get; set; }
    }
}