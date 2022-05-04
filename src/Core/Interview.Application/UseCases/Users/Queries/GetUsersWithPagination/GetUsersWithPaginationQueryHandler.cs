using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.Commons.Extensions;
using MediatR;

namespace Interview.Application.UseCases.Users.Queries.GetUsersWithPagination
{
    public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PagedResponse<GetUsersWithPaginationQueryResponse>>
    {
        private readonly IInterviewDbContext _context;

        public GetUsersWithPaginationQueryHandler(IInterviewDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<GetUsersWithPaginationQueryResponse>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
               .Select(c =>
                   new GetUsersWithPaginationQueryResponse
                   {
                       Id = c.ID,
                       Email = c.Email,
                       Name = c.Name,
                   })
               .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
