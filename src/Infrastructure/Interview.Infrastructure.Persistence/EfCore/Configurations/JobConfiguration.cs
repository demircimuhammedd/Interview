using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.Infrastructure.Persistence.EfCore.Configurations
{
    internal class JobConfiguration : BaseEntityConfiguraton<Job>
    {
        public override void Configure(EntityTypeBuilder<Job> builder)
        {
            base.Configure(builder);

            builder.HasOne(c => c.CreatedBy)
                .WithMany(c => c.Jobs)
                .HasForeignKey(c => c.CreatedById)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasMany(c => c.Positions)
                .WithMany(c => c.Jobs);

            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.EndedAt).IsRequired();

        }
    }
}
