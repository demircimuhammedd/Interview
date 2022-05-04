using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.Commons.Helpers;
using MediatR;

namespace Interview.Application.UseCases.BadVocables.Commands.CreateBadVocable
{
    public class CreateBadVocableCommandHandler : IRequestHandler<CreateBadVocableCommand, SingleResponse<bool>>
    {
        private readonly IInterviewDbContext _context;
        private readonly IMediator _mediator;

        public CreateBadVocableCommandHandler(IInterviewDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<SingleResponse<bool>> Handle(CreateBadVocableCommand request, CancellationToken cancellationToken)
        {
            SingleResponse<bool> response = new();

            var entity = new Domain.Entities.BadVocable
            {
                Name = request.Name
            };

            await _context.BadVocables.AddAsync(entity, cancellationToken);
            bool isSucced = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (isSucced)
            {
                await _mediator.Publish(new CreatedBadVocableNotification(), cancellationToken);
            }

            response.Data = isSucced;
            return response;
        }
    }
}
