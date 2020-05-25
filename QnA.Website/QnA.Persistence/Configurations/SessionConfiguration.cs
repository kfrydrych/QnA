using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QnA.Domain.Models;

namespace QnA.Persistence.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(250).IsRequired();
            builder.Property(x => x.AccessCode).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Owner).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Questions).WithOne(x => x.Session).IsRequired();
        }
    }
}
