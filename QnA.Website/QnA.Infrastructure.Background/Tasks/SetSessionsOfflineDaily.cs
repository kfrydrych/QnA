using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using QnA.Application.Interfaces;
using QnA.Domain.Models;
using System.Linq;
using System.Threading;

namespace QnA.Infrastructure.Background.Tasks
{
    public class SetSessionsOfflineDaily
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetSessionsOfflineDaily(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [FunctionName("set-sessions-offline-daily")]
        public async void Run([TimerTrigger("0 0 0 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("Attempting to set sessions offline...");

            var sessionsToUpdate = _unitOfWork.Sessions.Where(x => x.Status == Status.Online).ToList();

            sessionsToUpdate.ForEach(x => x.SetOffline());

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            log.LogInformation($"{sessionsToUpdate.Count} sessions updated.");
        }
    }
}
