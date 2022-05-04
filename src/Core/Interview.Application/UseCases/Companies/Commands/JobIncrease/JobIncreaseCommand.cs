using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;

namespace Interview.Application.UseCases.Companies.Commands.JobIncrease
{
    public class JobIncreaseCommand : IRequest<SingleResponse<bool>>
    {
        public Guid CompanyId { get; set; }
        public int Quantity { get; set; }
    }
}
