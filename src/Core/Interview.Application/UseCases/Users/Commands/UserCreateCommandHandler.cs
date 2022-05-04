using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.Commons.Helpers;
using MediatR;

namespace Interview.Application.UseCases.Users.Commands
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, SingleResponse<bool>>
    {
        private readonly IInterviewDbContext _context;

        public UserCreateCommandHandler(IInterviewDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();

            var entity = new Domain.Entities.User
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                JobQuantity = 2,
                Password = PasswordEncryptHelper.GeneratePassword(request.Password),
                PhoneNumber = request.PhoneNumber
            };

            await _context.Users.AddAsync(entity, cancellationToken);

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response;
        }
    }
}
