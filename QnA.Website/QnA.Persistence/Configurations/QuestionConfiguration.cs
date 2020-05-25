using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QnA.Domain.Models;

namespace QnA.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(x => x.Text).HasMaxLength(750).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Votes).WithOne(x => x.Question).IsRequired();
        }
    }
}
