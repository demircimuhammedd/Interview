using FluentValidation;
using Interview.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.UseCases.Jobs.Commands.CreateJob
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        private readonly IInterviewDbContext _context;

        public CreateJobCommandValidator(IInterviewDbContext context)
        {
            _context = context;

            RuleFor(v => v.CreatedById)
              .NotEmpty().WithMessage("Created by is required.")
              .MustAsync(BeExistUser).WithMessage("Created by not found.");

            RuleFor(v => v.Desciption)
               .NotEmpty().WithMessage("Desciption is required.")
               .MaximumLength(250).WithMessage("Desciption must not exceed 250 characters.");

            RuleForEach(x => x.PositionIds)
                .NotNull()
                .WithMessage("Position {CollectionIndex} is required."); 
                
        }

        private async Task<bool> BeExistUser(Guid id, CancellationToken cancellationToken) =>
           await _context.Users.AnyAsync(l => l.ID == id, cancellationToken);
    }
}
