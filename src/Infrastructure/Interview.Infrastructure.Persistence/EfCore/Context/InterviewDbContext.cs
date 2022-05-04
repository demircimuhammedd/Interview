using Interview.Application.Abstractions;
using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Interview.Infrastructure.Persistence.EfCore.Context
{
    public class InterviewDbContext : DbContext, IInterviewDbContext
    {
        public InterviewDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<BadVocable> BadVocables { get; set; }
        public DbSet<FringeBenefit> FringeBenefits { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
    }
}
