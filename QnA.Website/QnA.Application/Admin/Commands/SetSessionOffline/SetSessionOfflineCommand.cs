using System;
using MediatR;

namespace QnA.Application.Admin.Commands.SetSessionOffline
{
    public class SetSessionOfflineCommand : IRequest
    {
        public Guid SessionId { get; set; }
    }
}
