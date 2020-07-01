using MediatR;
using Microsoft.Azure.WebJobs;
using QnA.Application.Tasks.Commands.UpdateSessionsStatus;

namespace QnA.Infrastructure.Background.Tasks
{
    public class UpdateSessionsStatusDaily
    {
        private readonly IMediator _mediator;

        public UpdateSessionsStatusDaily(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("set-sessions-offline-daily")]
        public async void Run([TimerTrigger("0 0 0 * * *")]TimerInfo myTimer)
        {
            await _mediator.Send(new UpdateSessionsStatusCommand());
        }
    }
}
