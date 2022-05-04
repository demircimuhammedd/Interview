using FluentValidation;
using Interview.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.UseCases.Users.Commands.BadVocable
{
    public class CreateBadVocableCommandValidator : AbstractValidator<CreateBadVocableCommand>
    {
        private readonly IInterviewDbContext _context;

        public CreateBadVocableCommandValidator(IInterviewDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MustAsync(BeUniqueName).WithMessage("Name already exists.");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken) =>
           await _context.BadVocables.AllAsync(l => l.Name != name, cancellationToken);
    }
}
