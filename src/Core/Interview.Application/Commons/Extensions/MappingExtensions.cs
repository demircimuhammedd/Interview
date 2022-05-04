using AutoMapper;
using AutoMapper.QueryableExtensions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.Commons.Extensions
{
    public static class MappingExtensions
    {
        public static Task<PagedResponse<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
          => PagedResponse<TDestination>.CreateAsync(queryable, pageNumber, pageSize);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();

        //public static Task<PaginatedList<TDestination>> OldPaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
        //    => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
    }
}
