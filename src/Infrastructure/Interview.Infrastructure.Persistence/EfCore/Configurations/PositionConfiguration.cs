using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.Infrastructure.Persistence.EfCore.Configurations
{
    internal class PositionConfiguration : BaseEntityConfiguraton<Position>
    {
        public override void Configure(EntityTypeBuilder<Position> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired();
        }
    }
}
