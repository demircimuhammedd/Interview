using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;

namespace Interview.Application.UseCases.Users.Queries.GetUsersWithPagination
{
    public class GetUsersWithPaginationQuery : IRequest<PagedResponse<GetUsersWithPaginationQueryResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
