using MediatR;
using System.ComponentModel;

namespace QnA.Application.Admin.Commands.CreateSession
{
    public class CreateSessionCommand : IRequest
    {
        public string Title { get; set; }

        [DisplayName("Access Code")]
        public string AccessCode { get; set; }
    }
}
