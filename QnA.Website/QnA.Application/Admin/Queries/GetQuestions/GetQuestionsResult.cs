using System;
using System.Collections.Generic;

namespace QnA.Application.Admin.Queries.GetQuestions
{
    public class GetQuestionsResult
    {
        public IEnumerable<Question> Questions { get; set; }
        public class Question
        {
            public Guid Id { get; set; }
            public string Text { get; set; }
            public int Score { get; set; }
            public Guid SessionId { get; set; }
        }
    }
}
