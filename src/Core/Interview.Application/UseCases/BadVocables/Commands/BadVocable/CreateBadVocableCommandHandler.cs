using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.Commons.Helpers;
using MediatR;

namespace Interview.Application.UseCases.Users.Commands.BadVocable
{
    public class CreateBadVocableCommandHandler : IRequestHandler<CreateBadVocableCommand, SingleResponse<bool>>
    {
        private readonly IInterviewDbContext _context;

        public CreateBadVocableCommandHandler(IInterviewDbContext context)
        {
            _context = context;
        }

        public async Task<SingleResponse<bool>> Handle(CreateBadVocableCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();

            var entity = new Domain.Entities.BadVocable
            {
                Name = request.Name
            };

            await _context.BadVocables.AddAsync(entity, cancellationToken);

            response.Data = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response;
        }
    }
}
