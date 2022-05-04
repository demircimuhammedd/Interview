using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;

namespace Interview.Application.UseCases.Jobs.Queries.GetJobsWithPagination
{
    public class GetJobsWithPaginationQuery : IRequest<PagedResponse<GetJobsWithPaginationQueryResponse>>
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
