using Microsoft.EntityFrameworkCore;
using QnA.Application.Interfaces;
using QnA.Domain.Models;
using System.Reflection;

namespace QnA.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Session> Sessions { get; set; }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        //    {
        //        if (entry.State == EntityState.Modified)
        //        {
        //            if (entry.Entity is IAdminResource)
        //            {
        //                entry.Entity.CaptureUpdate(_user.Username, _dateService.Now);
        //            }

        //            if (entry.Entity is IAudienceResource)
        //            {
        //                entry.Entity.CaptureUpdate(_user.UniqueSource, _dateService.Now);
        //            }

        //            throw new ResourceOwnerNotProvidedException(typeof(ApplicationDbContext), entry.Entity);
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
