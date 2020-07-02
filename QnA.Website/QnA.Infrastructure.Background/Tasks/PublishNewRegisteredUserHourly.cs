using MediatR;
using Microsoft.Azure.WebJobs;
using QnA.Application.Tasks.Commands.PublishNewRegisteredUser;

namespace QnA.Infrastructure.Background.Tasks
{
    public class PublishNewRegisteredUserHourly
    {
        private readonly IMediator _mediator;

        public PublishNewRegisteredUserHourly(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("publish-new-registered-user-hourly")]
        public async void Run([TimerTrigger("0 0 * * * *")]TimerInfo myTimer)
        {
            await _mediator.Send(new PublishNewRegisteredUserCommand());
        }
    }
}
