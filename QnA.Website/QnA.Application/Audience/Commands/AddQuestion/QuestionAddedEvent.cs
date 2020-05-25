using System;
using MediatR;

namespace QnA.Application.Audience.Commands.AddQuestion
{
    public class QuestionAddedEvent : INotification
    {
        public Guid QuestionId { get; set; }
    }
}