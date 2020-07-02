using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using QnA.Application.Tasks.Commands.UpdateSessionsStatus;
using System.Threading.Tasks;

namespace QnA.Infrastructure.Background.Tasks
{
    public class UpdateSessionsStatusTrigger
    {
        private readonly IMediator _mediator;

        public UpdateSessionsStatusTrigger(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("update-sessions-status")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            await _mediator.Send(new UpdateSessionsStatusCommand());

            return new OkResult();
        }
    }



}
