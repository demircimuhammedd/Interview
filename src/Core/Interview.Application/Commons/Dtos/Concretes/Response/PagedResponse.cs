using Interview.Application.Commons.Dtos.Abstractions.Response;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.Commons.Dtos.Concretes.Response;

public class PagedResponse<TData> : IPagedResponse<TData>
{
    public string Message { get; set; }
    public bool DidError => ErrorMessages.Any();
    public List<string> ErrorMessages { get; set; } = new();
    public IEnumerable<TData> Data { get; set; }

    public int PageIndex { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public PagedResponse(IEnumerable<TData> data, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Data = data;
    }

    public static async Task<PagedResponse<TData>> CreateAsync(IQueryable<TData> source, int pageIndex, int pageSize)
    {
        int count = await source.CountAsync();
        List<TData> items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResponse<TData>(items, count, pageIndex, pageSize);
    }
}