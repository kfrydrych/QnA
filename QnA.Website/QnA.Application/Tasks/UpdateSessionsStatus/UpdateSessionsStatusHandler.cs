﻿using MediatR;
using QnA.Application.Interfaces;
using QnA.Domain.Interfaces;
using QnA.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Tasks.UpdateSessionsStatus
{
    public class UpdateSessionsStatusHandler : IRequestHandler<UpdateSessionsStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateService _dateService;
        private readonly IUser _user;

        public UpdateSessionsStatusHandler(IUnitOfWork unitOfWork, IDateService dateService, IUser user)
        {
            _unitOfWork = unitOfWork;
            _dateService = dateService;
            _user = user;
        }

        public async Task<Unit> Handle(UpdateSessionsStatusCommand request, CancellationToken cancellationToken)
        {
            var sessionsToBeOffline = _unitOfWork.Sessions.Where(x => x.Status == Status.Online && x.LastModified < _dateService.Now.AddDays(-1)).ToList();

            sessionsToBeOffline.ForEach(x => x.SetOffline(_user.Username, _dateService));

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}