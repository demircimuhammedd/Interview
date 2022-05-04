using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview.Infrastructure.Persistence.EfCore.Configurations
{
    public abstract class BaseEntityConfiguraton<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.CreatedAt).ValueGeneratedOnAdd();
        }
    }
}
