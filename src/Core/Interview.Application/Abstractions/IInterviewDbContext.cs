using Interview.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.Abstractions
{
    public interface IInterviewDbContext
    {
        public DbSet<BadVocable> BadVocables { get; set; }
        public DbSet<FringeBenefit> FringeBenefits { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
