using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.Infrastructure.Persistence.EfCore.Configurations
{
    public class UserConfiguraton : BaseEntityConfiguraton<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasMany(c => c.Jobs)
                .WithOne(c => c.CreatedBy)
                .HasForeignKey(c => c.CreatedById);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.Property(c => c.Address).IsRequired();
            builder.Property(c => c.JobQuantity).IsRequired();

            builder.HasIndex(c => c.PhoneNumber).IsUnique();
        }
    }
}
