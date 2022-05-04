using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.Infrastructure.Persistence.EfCore.Configurations
{
    public class BadVocableConfiguration : BaseEntityConfiguraton<BadVocable>
    {
        public override void Configure(EntityTypeBuilder<BadVocable> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired();
        }
    }
}
