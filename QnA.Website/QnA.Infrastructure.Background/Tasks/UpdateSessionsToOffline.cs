using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using QnA.Application.Interfaces;
using QnA.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Infrastructure.Background.Tasks
{
    public class UpdateSessionsToOffline
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSessionsToOffline(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [FunctionName("update-sessions-to-offline")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Attempting to set sessions offline...");

            var sessionsToUpdate = _unitOfWork.Sessions.Where(x => x.Status == Status.Online).ToList();

            sessionsToUpdate.ForEach(x => x.SetOffline());

            await _unitOfWork.SaveChangesAsync(CancellationToken.None);

            log.LogInformation($"{sessionsToUpdate.Count} sessions updated.");

            return new OkObjectResult($"{sessionsToUpdate.Count} sessions updated.");
        }
    }



}
