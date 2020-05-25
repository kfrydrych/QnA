using MediatR;
using Microsoft.AspNetCore.Mvc;
using QnA.Application.Audience.Commands.AddQuestion;
using QnA.Application.Audience.Queries.GetSession;
using System;
using System.Threading.Tasks;

namespace QnA.Website.Controllers
{
    public class AudienceController : Controller
    {
        private readonly IMediator _mediator;

        public AudienceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Session(Guid id)
        {
            var result = await _mediator.Send(new GetSessionQuery { SessionId = id });
            return View(result);
        }

        public async Task<IActionResult> AskQuestion(AddQuestionCommand command)
        {
            if (!ModelState.IsValid)
                return PartialView("_AskQuestion", command);

            await _mediator.Send(command);
            return PartialView("_AskQuestion");
        }
    }
}