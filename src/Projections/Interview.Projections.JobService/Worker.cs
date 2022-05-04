using Nest;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ServiceStack.Messaging;
using System.Text;

namespace Interview.Projections.JobService
{
    public class Worker : BackgroundService
    {
        private const int MqStatsDescriptionDurationMs = 10000;

        private readonly ElasticClient _elasticsearchClient;
        private readonly ILogger<Worker> _logger;

        private readonly IModel _channel;
        private readonly IConnection _connection;

        public Worker(ILogger<Worker> logger, ElasticClient elasticsearchClient)
        {
            _logger = logger;
            _elasticsearchClient = elasticsearchClient;


            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "jobs", exclusive: false);


        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var job = JsonConvert.DeserializeObject<Job>(content);

                _logger.LogInformation("Received Data {@data}", job);

                var response = await _elasticsearchClient.IndexAsync(job, idx => idx.Index("jobs"));

                _logger.LogInformation("Received Data index elasticsearch {@data}", response);

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerCancelled;

            _channel.BasicConsume("jobs", false, consumer);

            return Task.CompletedTask;
        }


        private void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}