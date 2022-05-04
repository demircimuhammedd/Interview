using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;

namespace Interview.Application.UseCases.Jobs.Commands.CreateJob
{
    public class CreateJobCommand : IRequest<SingleResponse<bool>>
    {
        public Guid CreatedById { get; set; }
        public string Desciption { get; set; }
        public List<Guid?> FringeBenefitIds { get; set; }
        public List<Guid?> WorkTypeIds { get; set; }
        public List<Guid> PositionIds { get; set; }
        public decimal? Salary { get; set; }
    }
}
