using MediatR;
using Microsoft.AspNetCore.Mvc;
using QnA.Application.Audience.Commands.PromoteQuestion;
using QnA.Application.Audience.Queries.GetQuestions;
using System;
using System.Threading.Tasks;

namespace QnA.Website.Controllers.Api
{
    [Route("api/audience")]
    [ApiController]
    public class AudienceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AudienceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("questions/sessionId/{sessionId}")]
        public async Task<IActionResult> Get(Guid sessionId)
        {
            var result = await _mediator.Send(new GetQuestionsQuery { SessionId = sessionId });
            return Ok(result);
        }

        [HttpPost]
        [Route("questions/promote")]
        public async Task<IActionResult> Promote([FromForm] PromoteQuestionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}