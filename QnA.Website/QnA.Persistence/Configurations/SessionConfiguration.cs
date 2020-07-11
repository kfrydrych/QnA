using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QnA.Domain.Models;

namespace QnA.Persistence.Configurations
{
    public class SessionConfiguration : AuditableEntityConfiguration<Session>
    {
        public override void Configure(EntityTypeBuilder<Session> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title).HasMaxLength(250).IsRequired();
            builder.Property(x => x.AccessCode).HasMaxLength(50).IsRequired();
            builder.HasMany(x => x.Questions).WithOne(x => x.Session).IsRequired();

            builder.HasIndex(i => new { i.CreatedBy, i.Created })
                .IncludeProperties(x => new { x.Title, x.Status });

            builder.HasIndex(i => new { i.AccessCode, i.Status })
                .IncludeProperties(x => x.Title);
        }
    }
}
