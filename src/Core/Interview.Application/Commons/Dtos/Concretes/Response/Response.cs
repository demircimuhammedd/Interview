using Interview.Application.Commons.Dtos.Abstractions.Response;

namespace Interview.Application.Commons.Dtos.Concretes.Response;

public class Response : IResponse
{
    public string Message { get; set; }
    public bool DidError => ErrorMessages.Any();
    public List<string> ErrorMessages { get; set; } = new();
}