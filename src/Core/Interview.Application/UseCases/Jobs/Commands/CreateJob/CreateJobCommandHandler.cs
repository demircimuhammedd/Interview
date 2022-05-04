using Interview.Application.Abstractions;
using Interview.Application.Commons.Dtos.Concretes.Response;
using Interview.Application.UseCases.Jobs.Commands.RateCalculator;
using MediatR;

namespace Interview.Application.UseCases.Jobs.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, SingleResponse<bool>>
    {
        private readonly IInterviewDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMessageProducer _messagePublisher;

        public CreateJobCommandHandler(IInterviewDbContext context, IMessageProducer messagePublisher, IMediator mediator)
        {
            _context = context;
            _messagePublisher = messagePublisher;
            _mediator = mediator;
        }

        public async Task<SingleResponse<bool>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var response = new SingleResponse<bool>();
            var entity = new Domain.Entities.Job
            {
                CreatedById = request.CreatedById,
                Description = request.Desciption,
                EndedAt = DateTime.UtcNow.AddDays(15),
                //FringeBenefit = request.FringeBenefitIds.Select(c => new Domain.Entities.FringeBenefit { ID = c.Value }).ToList(),
                //Positions = request.PositionIds.Select(c => new Domain.Entities.Position { ID = c }).ToList(),
                //WorkType = request.WorkTypeIds.Select(c => new Domain.Entities.WorkType { ID = c.Value }).ToList(),
                Salary = request.Salary
            };

            await _context.Jobs.AddAsync(entity, cancellationToken);

            bool isSucced = await _context.SaveChangesAsync(cancellationToken) > 0;

            if (isSucced)
            {
                await _mediator.Publish(new RateCalculaterNotification { JobId = entity.ID }, cancellationToken); 
                _messagePublisher.SendMessage(entity);
            }

            response.Data = isSucced;

            return response;
        }
    }
}
