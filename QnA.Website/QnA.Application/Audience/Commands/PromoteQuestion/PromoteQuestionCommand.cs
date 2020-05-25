using MediatR;
using System;

namespace QnA.Application.Audience.Commands.PromoteQuestion
{
    public class PromoteQuestionCommand : IRequest
    {
        public Guid QuestionId { get; set; }
        public Guid SessionId { get; set; }
    }
}
