using Microsoft.EntityFrameworkCore;
using QnA.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace QnA.Application.Interfaces
{
    public interface IUnitOfWork
    {
        DbSet<Question> Questions { get; set; }
        DbSet<Session> Sessions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}