using Interview.Application.Commons.Dtos.Abstractions.Response;

namespace Interview.Application.Commons.Dtos.Concretes.Response;

public class SingleResponse<TData> : ISingleResponse<TData>
{
    public string Message { get; set; }
    public bool DidError => ErrorMessages.Any();
    public List<string> ErrorMessages { get; set; } = new();
    public TData Data { get; set; }
}