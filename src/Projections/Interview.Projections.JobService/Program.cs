using Elasticsearch.Net;
using Interview.Projections.JobService;
using Nest;
using ServiceStack;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {  
        services.AddHostedService<Worker>();
        var settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri("http://localhost:9200/")));
        var client = new ElasticClient(settings);
        services.AddSingleton(client);
    })
    .Build();

await host.RunAsync();
