using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;

namespace Interview.Application.UseCases.BadVocables.Queries.GetBadVocables
{
    public class GetBadVocablesQuery : IRequest<ListResponse<string>>
    {
    }
}
