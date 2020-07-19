using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QnA.Application.Admin.Commands.CreateSession;
using QnA.Application.Admin.Commands.SetSessionOffline;
using QnA.Application.Admin.Commands.SetSessionOnline;
using QnA.Application.Admin.Queries.GetActiveSession;
using QnA.Application.Admin.Queries.GetSession;
using QnA.Application.Admin.Queries.GetSessions;
using System;
using System.Threading.Tasks;

namespace QnA.Website.Controllers
{
    [Authorize]
    public class SessionsController : Controller
    {
        private readonly IMediator _mediator;

        public SessionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? limit)
        {
            var result = await _mediator.Send(new GetSessionsQuery(limit));
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateSessionCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSessionCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Active(Guid id)
        {
            var result = await _mediator.Send(new GetActiveSessionQuery { SessionId = id });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> SetOnline(Guid id)
        {
            await _mediator.Send(new SetSessionOnlineCommand { SessionId = id });
            var result = await _mediator.Send(new GetSessionQuery { SessionId = id });
            return PartialView("_SessionColumns", result);
        }

        [HttpPost]
        public async Task<IActionResult> SetOffline(Guid id)
        {
            await _mediator.Send(new SetSessionOfflineCommand { SessionId = id });
            var result = await _mediator.Send(new GetSessionQuery { SessionId = id });
            return PartialView("_SessionColumns", result);
        }
    }
}
