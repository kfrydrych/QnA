using MediatR;
using QnA.Application.Interfaces;
using QnA.Domain.Interfaces;
using QnA.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Admin.Commands.CreateSession
{
    public class CreateSessionHandler : IRequestHandler<CreateSessionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateService _dateService;
        private readonly IUser _user;

        public CreateSessionHandler(IUnitOfWork unitOfWork, IDateService dateService, IUser user)
        {
            _unitOfWork = unitOfWork;
            _dateService = dateService;
            _user = user;
        }

        public async Task<Unit> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            var session = new Session(request.Title, request.AccessCode, _user.Username, _dateService);

            _unitOfWork.Sessions.Add(session);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}