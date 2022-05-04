using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;

namespace Interview.Application.UseCases.BadVocables.Queries.GetBadVocables
{
    public class GetBadVocablesQueryHandler : IRequestHandler<GetBadVocablesQuery, ListResponse<string>>
    {
        private readonly ICacheService _cacheService;

        public GetBadVocablesQueryHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<ListResponse<string>> Handle(GetBadVocablesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _cacheService.GetAsync<List<string>>("BadVocables");
            var response = new ListResponse<string>
            {
                Data = entities
            };

            return response;
        }
    }
}
