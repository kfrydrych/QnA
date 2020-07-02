using MediatR;
using Microsoft.Azure.WebJobs;
using QnA.Application.Tasks.Commands.PublishNewRegisteredUsers;

namespace QnA.Infrastructure.Background.Tasks
{
    public class PublishNewRegisteredUser
    {
        private readonly IMediator _mediator;

        public PublishNewRegisteredUser(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("publish-new-registered-user")]
        public async void Run([TimerTrigger("0 0 * * * *")]TimerInfo myTimer)
        {
            await _mediator.Send(new PublishNewRegisteredUserCommand());
        }
    }
}
