using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QnA.Domain.Common;

namespace QnA.Persistence.Configurations
{
    public class AuditRecordConfiguration : IEntityTypeConfiguration<AuditRecord>
    {
        public void Configure(EntityTypeBuilder<AuditRecord> builder)
        {
            builder.Property(x => x.TableName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.EventMessage).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ModifiedBy).IsRequired().HasMaxLength(150);
        }
    }
}
