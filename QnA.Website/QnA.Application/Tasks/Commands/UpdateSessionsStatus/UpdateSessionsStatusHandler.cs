using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using QnA.Application.Interfaces;
using QnA.Domain.Interfaces;
using QnA.Domain.Models;

namespace QnA.Application.Tasks.Commands.UpdateSessionsStatus
{
    public class UpdateSessionsStatusHandler : IRequestHandler<UpdateSessionsStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateService _dateService;
        private readonly IUser _user;
        private readonly ILogger _logger;

        public UpdateSessionsStatusHandler(IUnitOfWork unitOfWork, IDateService dateService, IUser user, ILoggerFactory loggerFactory)
        {
            _unitOfWork = unitOfWork;
            _dateService = dateService;
            _user = user;
            _logger = loggerFactory.CreateLogger<UpdateSessionsStatusHandler>();
        }

        public async Task<Unit> Handle(UpdateSessionsStatusCommand request, CancellationToken cancellationToken)
        {
            var sessionsToBeOffline = _unitOfWork.Sessions
                .Where(x => x.Status == Status.Online &&
                            x.LastModified < _dateService.Now.AddDays(-1))
                .ToList();

            sessionsToBeOffline.ForEach(x => x.SetOffline(_user.Username, _dateService));

            var sessionsToBeArchived = _unitOfWork.Sessions
                .Where(x => x.Questions.Any() &&
                            x.Status == Status.Offline &&
                            x.LastModified < _dateService.Now.AddDays(-7))
                .ToList();

            sessionsToBeArchived.ForEach(x => x.Archive(_user.Username, _dateService));

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            #region Logs
            _logger.LogInformation($"{sessionsToBeOffline.Count} session(s) set to offline");
            _logger.LogInformation($"{sessionsToBeArchived.Count} session(s) archived");
            #endregion

            return Unit.Value;
        }
    }
}