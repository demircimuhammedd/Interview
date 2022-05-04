using FluentValidation;
using Interview.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.UseCases.Companies.Commands.JobIncrease
{
    public class JobIncreaseCommandValidator : AbstractValidator<JobIncreaseCommand>
    {
        private readonly IInterviewDbContext _context;

        public JobIncreaseCommandValidator(IInterviewDbContext context)
        {
            _context = context;

            RuleFor(v => v.CompanyId)
           .NotEmpty().WithMessage("Company is required.")
           .MustAsync(BeExistUser).WithMessage("Company not found.");
        }

        private async Task<bool> BeExistUser(Guid id, CancellationToken cancellationToken) =>
          await _context.Users.AnyAsync(l => l.ID == id, cancellationToken);
    }
}
