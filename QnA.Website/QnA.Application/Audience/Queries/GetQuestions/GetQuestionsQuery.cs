using MediatR;
using System;

namespace QnA.Application.Audience.Queries.GetQuestions
{
    public class GetQuestionsQuery : IRequest<GetQuestionsResult>
    {
        public Guid SessionId { get; set; }
    }
}
