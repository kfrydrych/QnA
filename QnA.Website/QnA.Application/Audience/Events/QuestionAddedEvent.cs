using System;
using MediatR;

namespace QnA.Application.Audience.Events
{
    public class QuestionAddedEvent : INotification
    {
        public Guid QuestionId { get; set; }
    }
}