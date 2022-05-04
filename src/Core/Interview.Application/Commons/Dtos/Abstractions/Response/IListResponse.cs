namespace Interview.Application.Commons.Dtos.Abstractions.Response;

public interface IListResponse<TData> : IResponse
{
    IEnumerable<TData> Data { get; set; }
}