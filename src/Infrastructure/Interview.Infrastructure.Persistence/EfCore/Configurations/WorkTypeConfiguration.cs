using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.Infrastructure.Persistence.EfCore.Configurations
{
    public class WorkTypeConfiguration : BaseEntityConfiguraton<WorkType>
    {
        public override void Configure(EntityTypeBuilder<WorkType> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired();
        }
    }
}
