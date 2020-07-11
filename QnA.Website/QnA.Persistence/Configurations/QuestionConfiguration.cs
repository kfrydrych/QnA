using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QnA.Domain.Models;

namespace QnA.Persistence.Configurations
{
    public class QuestionConfiguration : AuditableEntityConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Text).HasMaxLength(750).IsRequired();
            builder.HasMany(x => x.Votes).WithOne(x => x.Question).IsRequired();

            builder.HasIndex(i => new { i.SessionId, i.Score })
                .IncludeProperties(x => new { x.Text, x.CreatedBy });
        }
    }
}
