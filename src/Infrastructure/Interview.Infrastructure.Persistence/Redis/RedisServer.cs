using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Interview.Infrastructure.Persistence.Redis
{
    public class RedisServer
    {
        private readonly IDatabase _database;
        private readonly int _currentDatabaseId = 0;
        private readonly string _databaseConnectionString;
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public IDatabase Database => _database;

        public RedisServer(IConfiguration configuration)
        {
            string host = configuration["Redis:Host"];
            string port = configuration["Redis:Port"];

            _databaseConnectionString = $"{host}:{port}";

            _connectionMultiplexer = ConnectionMultiplexer.Connect(_databaseConnectionString);
            _database = _connectionMultiplexer.GetDatabase(_currentDatabaseId);
        }

        public void FlushDatabase()
        {
            _connectionMultiplexer.GetServer(_databaseConnectionString).FlushDatabase(_currentDatabaseId);
        }
    }
}
