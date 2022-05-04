using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.Commons.Extensions;
using MediatR;
using Nest;

namespace Interview.Application.UseCases.Jobs.Queries.GetJobsWithPagination
{
    public class GetJobsWithPaginationQueryHandler : IRequestHandler<GetJobsWithPaginationQuery, PagedResponse<GetJobsWithPaginationQueryResponse>>
    {
        private readonly ElasticClient _client;
        private readonly IInterviewDbContext _context;

        public GetJobsWithPaginationQueryHandler(IInterviewDbContext context, ElasticClient client)
        {
            _context = context;
            _client = client;
        }

        public async Task<PagedResponse<GetJobsWithPaginationQueryResponse>> Handle(GetJobsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var searchRequest = new SearchRequest
            {
                From = request.PageNumber - 1,
                Size = request.PageSize,
                Query = new TermQuery { Field = "CreatedBy", Value = request.CompanyName } || new MatchQuery { Field = "description", Query = request.Description }
            };

            var elasticResponse = await _client.SearchAsync<Domain.Entities.Job>(searchRequest, cancellationToken);

            var response = elasticResponse.Documents.Select(c =>
                    new GetJobsWithPaginationQueryResponse
                    {
                        Id = c.ID,
                        Description = c.Description,
                        Rate = c.Rate,
                        EndedAt = c.EndedAt
                    });


            return new PagedResponse<GetJobsWithPaginationQueryResponse>(response, (int)elasticResponse.Total, request.PageNumber, request.PageSize);
        }
    }
}
