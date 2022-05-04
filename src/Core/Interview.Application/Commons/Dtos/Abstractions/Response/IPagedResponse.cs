namespace Interview.Application.Commons.Dtos.Abstractions.Response;

public interface IPagedResponse<TData> : IListResponse<TData>
{
    public int PageIndex { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }
    public bool HasPreviousPage { get; }
    public bool HasNextPage { get; }
}