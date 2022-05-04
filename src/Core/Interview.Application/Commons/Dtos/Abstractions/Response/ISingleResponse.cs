namespace Interview.Application.Commons.Dtos.Abstractions.Response;

public interface ISingleResponse<TData> : IResponse
{
    TData Data { get; set; }
}