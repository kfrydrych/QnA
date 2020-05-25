using System;
using MediatR;

namespace QnA.Application.Audience.Commands.PromoteQuestion
{
    public class QuestionPromotedEvent : INotification
    {
        public Guid QuestionId { get; set; }
    }
}