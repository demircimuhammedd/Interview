using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;

namespace Interview.Application.UseCases.BadVocables.Commands.CreateBadVocable
{
    public class CreateBadVocableCommand : IRequest<SingleResponse<bool>>
    {
        public string Name { get; set; }
    }
}
