using System;

namespace QnA.Application.Messages
{
    public class NewUserRegisteredEvent : IMessage
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ApplicationId { get; set; }
        public DateTime EventDate { get; set; }
    }
}
