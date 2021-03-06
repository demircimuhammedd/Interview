using Elasticsearch.Net;
using Interview.Application.Abstractions;
using Interview.Infrastructure.Persistence.EfCore.Context;
using Interview.Infrastructure.Persistence.RabbitMq;
using Interview.Infrastructure.Persistence.Redis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

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
            services.AddSingleton<RedisServer>();
            services.AddSingleton<ICacheService, RedisCacheService>();
             

            var settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri(configuration["Elasticsearch:Host"])));
            var client = new ElasticClient(settings);
            services.AddSingleton(client);

           services.AddScoped<IMessageProducer, RabbitMQProducer>();

            return services;
        }
    }
}
