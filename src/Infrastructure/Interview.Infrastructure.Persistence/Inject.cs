using Interview.Application.Abstractions;
using Interview.Infrastructure.Persistence.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Interview.Infrastructure.Persistence
{
    public static class Inject
    {
        public static IServiceCollection AddEfCoreInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
            .AddEntityFrameworkNpgsql()
            .AddDbContext<InterviewDbContext>(options => options
                .UseNpgsql(configuration
                    .GetConnectionString("DefaultConnection"), b => b
                    .MigrationsAssembly(typeof(InterviewDbContext).Assembly.FullName)));

            services.AddScoped<IInterviewDbContext>(provider => provider.GetService<InterviewDbContext>());

            return services;
        }
    }
}
