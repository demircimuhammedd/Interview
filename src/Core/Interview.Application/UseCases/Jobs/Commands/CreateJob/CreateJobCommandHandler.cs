using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;

namespace Interview.Application.UseCases.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, SingleResponse<bool>>
    {
        private readonly IInterviewDbContext _context;

        public CreateJobCommandHandler(IInterviewDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var response = new SingleResponse<bool>();
            await _context.Jobs.AddAsync(new Domain.Entities.Job
            {
                CreatedById = request.CreatedById,
                Description = request.Desciption,
                EndedAt = DateTime.UtcNow.AddDays(15),
                FringeBenefit = request.FringeBenefitIds.Select(c => new Domain.Entities.FringeBenefit { ID = c.Value }).ToList(),
                Positions = request.PositionIds.Select(c => new Domain.Entities.Position { ID = c }).ToList(),
                WorkType = request.WorkTypeIds.Select(c => new Domain.Entities.WorkType { ID = c.Value }).ToList(),
                Salary = request.Salary,
                Rate = 1//TODO: Hesaplanacak
            }, cancellationToken);

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;

            return response;
        }
    }
}
