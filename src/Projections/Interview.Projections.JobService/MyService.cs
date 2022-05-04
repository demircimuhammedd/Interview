using ServiceStack;

namespace Interview.Projections.JobService
{
    public class MyService : Service
    {
        public object Any(Hello request) => new HelloResponse
        {
            Result = $"Hello, {request.Name}!"
        };
    }

    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
