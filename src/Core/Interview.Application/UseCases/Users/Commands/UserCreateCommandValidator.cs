using FluentValidation;
using Interview.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.UseCases.Users.Commands
{
    public class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
    {
        private readonly IInterviewDbContext _context;

        public UserCreateCommandValidator(IInterviewDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MustAsync(BeUniqueName).WithMessage("Name already exists.");

            RuleFor(v => v.PhoneNumber)
               .NotEmpty().WithMessage("Phone number is required.")
               .MaximumLength(15).WithMessage("Phone number must not exceed 15 characters.")
               .MustAsync(BeUniquePhoneNumber).WithMessage("Phone number already exists.");

            RuleFor(v => v.Address)
             .NotEmpty().WithMessage("Address is required.");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken) =>
           await _context.Users.AllAsync(l => l.Name != name, cancellationToken);

        private async Task<bool> BeUniquePhoneNumber(string name, CancellationToken cancellationToken) =>
           await _context.Users.AllAsync(l => l.Name != name, cancellationToken);
    }
}
