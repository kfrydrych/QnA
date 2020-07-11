using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QnA.Domain.Models;

namespace QnA.Persistence.Configurations
{
    public class VoteConfiguration : AuditableEntityConfiguration<Vote>
    {
        public override void Configure(EntityTypeBuilder<Vote> builder)
        {
            base.Configure(builder);

            builder.HasIndex(i => new { i.QuestionId, i.CreatedBy });
        }
    }
}
