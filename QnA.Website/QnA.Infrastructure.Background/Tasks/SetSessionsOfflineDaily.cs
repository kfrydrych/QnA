using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using QnA.Application.Interfaces;
using QnA.Domain.Interfaces;
using QnA.Domain.Models;
using System.Linq;
using System.Threading;

namespace QnA.Infrastructure.Background.Tasks
{
    public class SetSessionsOfflineDaily
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUser _user;
        private readonly IDateService _dateService;

        public SetSessionsOfflineDaily(IUnitOfWork unitOfWork, IUser user, IDateService dateService)
        {
            _unitOfWork = unitOfWork;
            _user = user;
            _dateService = dateService;
        }

        [FunctionName("set-sessions-offline-daily")]
        public async void Run([TimerTrigger("0 0 0 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Attempting to set sessions offline...");

            var sessionsToUpdate = _unitOfWork.Sessions.Where(x => x.Status == Status.Online).ToList();

            sessionsToUpdate.ForEach(x => x.SetOffline(_user.Username, _dateService));

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            log.LogInformation($"{sessionsToUpdate.Count} sessions updated.");
        }
    }
}
