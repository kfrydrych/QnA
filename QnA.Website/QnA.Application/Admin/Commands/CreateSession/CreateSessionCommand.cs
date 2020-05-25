using MediatR;

namespace QnA.Application.Admin.Commands.CreateSession
{
    public class CreateSessionCommand : IRequest
    {
        public string Title { get; set; }
        public string AccessCode { get; set; }
    }
}
