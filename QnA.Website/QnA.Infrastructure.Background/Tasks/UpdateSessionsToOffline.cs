using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;
using QnA.Application.Tasks.Commands.UpdateSessionsStatus;

namespace QnA.Infrastructure.Background.Tasks
{
    public class UpdateSessionsToOffline
    {
        private readonly IMediator _mediator;

        public UpdateSessionsToOffline(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("update-sessions-to-offline")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            await _mediator.Send(new UpdateSessionsStatusCommand());

            return new OkResult();
        }
    }



}
