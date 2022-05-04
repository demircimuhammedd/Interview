using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.Infrastructure.Persistence.EfCore.Configurations
{
    internal class FringeBenefitConfiguration : BaseEntityConfiguraton<FringeBenefit>
    {
        public override void Configure(EntityTypeBuilder<FringeBenefit> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).IsRequired();
        }
    }
}
