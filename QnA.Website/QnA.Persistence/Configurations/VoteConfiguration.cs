using QnA.Domain.Models;

namespace QnA.Persistence.Configurations
{
    public class VoteConfiguration : AuditableEntityConfiguration<Vote>
    {
        //public void Configure(EntityTypeBuilder<Vote> builder)
        //{
        //    builder.Property(x => x.CreatedBy).HasMaxLength(50).IsRequired();
        //}
    }
}
