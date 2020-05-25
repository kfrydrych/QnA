using MediatR;
using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Domain.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Admin.Commands.SetSessionOnline
{
    public class SetSessionOnlineHandler : IRequestHandler<SetSessionOnlineCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetSessionOnlineHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SetSessionOnlineCommand request, CancellationToken cancellationToken)
        {
            var session = await _unitOfWork.Sessions
                .Where(x => x.Id == request.SessionId)
                .SingleOrDefaultAsync(cancellationToken);

            if (session == null)
                throw new NotFoundException(typeof(SetSessionOnlineHandler), "Session not found");

            session.SetOnline();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}