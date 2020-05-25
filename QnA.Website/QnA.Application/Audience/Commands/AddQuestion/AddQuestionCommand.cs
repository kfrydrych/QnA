using System;
using MediatR;

namespace QnA.Application.Audience.Commands.AddQuestion
{
    public class AddQuestionCommand : IRequest
    {
        public string Text { get; set; }
        public Guid SessionId { get; set; }
    }
}
