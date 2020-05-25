using QnA.Application.Audience.Commands.AddQuestion;
using System;

namespace QnA.Application.Audience.Queries.GetSession
{
    public class GetSessionResult
    {
        public Guid SessionId { get; set; }
        public string Title { get; set; }
        public AddQuestionCommand AddQuestionCommand { get; set; }
    }
}