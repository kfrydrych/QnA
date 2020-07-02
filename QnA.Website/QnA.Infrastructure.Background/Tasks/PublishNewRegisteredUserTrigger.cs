using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using QnA.Application.Tasks.Commands.PublishNewRegisteredUser;
using System.Threading.Tasks;

namespace QnA.Infrastructure.Background.Tasks
{
    public class PublishNewRegisteredUserTrigger
    {
        private readonly IMediator _mediator;

        public PublishNewRegisteredUserTrigger(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("publish-new-registered-user-trigger")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            await _mediator.Send(new PublishNewRegisteredUserCommand());
            return new OkResult();
        }
    }
}
