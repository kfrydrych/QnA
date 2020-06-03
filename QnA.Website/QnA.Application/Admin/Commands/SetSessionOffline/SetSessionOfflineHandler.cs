using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Domain.Exceptions;
using QnA.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Admin.Commands.SetSessionOffline
{
    public class SetSessionOfflineHandler : IRequestHandler<SetSessionOfflineCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUser _user;
        private readonly IDateService _dateService;

        public SetSessionOfflineHandler(IUnitOfWork unitOfWork, IUser user, IDateService dateService)
        {
            _unitOfWork = unitOfWork;
            _user = user;
            _dateService = dateService;
        }

        public async Task<Unit> Handle(SetSessionOfflineCommand request, CancellationToken cancellationToken)
        {
            var session = await _unitOfWork.Sessions
                .Where(x => x.Id == request.SessionId)
                .SingleOrDefaultAsync(cancellationToken);

            if (session == null)
                throw new NotFoundException(typeof(SetSessionOfflineHandler), "Session not found");

            session.SetOffline(_user.Username, _dateService);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}