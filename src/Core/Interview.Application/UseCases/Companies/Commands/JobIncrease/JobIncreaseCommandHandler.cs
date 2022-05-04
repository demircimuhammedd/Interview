using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.UseCases.Companies.Commands.JobIncrease
{
    public class JobIncreaseCommandHandler : IRequestHandler<JobIncreaseCommand, SingleResponse<bool>>
    {
        private readonly IInterviewDbContext _context;

        public JobIncreaseCommandHandler(IInterviewDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(JobIncreaseCommand request, CancellationToken cancellationToken)
        {
            var response = new SingleResponse<bool>();

            var entity = await _context.Users.FirstOrDefaultAsync(c => c.ID == request.CompanyId, cancellationToken: cancellationToken);
            entity.JobQuantity = request.Quantity;

            _context.Users.Update(entity);
            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;

            return response;
        }
    }
}
