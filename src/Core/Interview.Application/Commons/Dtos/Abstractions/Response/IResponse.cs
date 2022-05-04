namespace Interview.Application.Commons.Dtos.Abstractions.Response;

public interface IResponse
{
    string Message { get; set; }
    bool DidError { get; }
    public List<string> ErrorMessages { get; set; }
}