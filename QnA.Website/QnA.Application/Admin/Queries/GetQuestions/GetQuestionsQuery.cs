using System;
using MediatR;

namespace QnA.Application.Admin.Queries.GetQuestions
{
    public class GetQuestionsQuery : IRequest<GetQuestionsResult>
    {
        public Guid SessionId { get; set; }
    }
}