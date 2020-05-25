using MediatR;
using System;

namespace QnA.Application.Admin.Commands.SetSessionOnline
{
    public class SetSessionOnlineCommand : IRequest
    {
        public Guid SessionId { get; set; }
    }
}
