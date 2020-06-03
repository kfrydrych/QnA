using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QnA.Domain.Common;

namespace QnA.Persistence.Configurations
{
    public class AuditableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastModifiedBy).HasMaxLength(100);
            builder.Property(x => x.LastChangeEvent).IsRequired().HasMaxLength(150);
        }
    }
}
