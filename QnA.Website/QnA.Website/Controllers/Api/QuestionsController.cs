using MediatR;
using Microsoft.AspNetCore.Mvc;
using QnA.Application.Admin.Queries.GetQuestions;
using System;
using System.Threading.Tasks;

namespace QnA.Website.Controllers.Api
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("sessionId/{sessionId}")]
        public async Task<IActionResult> Get(Guid sessionId)
        {
            var result = await _mediator.Send(new GetQuestionsQuery { SessionId = sessionId });
            return Ok(result);
        }
    }
}