using Interview.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.UseCases.Jobs.Commands.RateCalculator
{
    public class RateCalculaterNotificationHandler : INotificationHandler<RateCalculaterNotification>
    {
        private readonly IInterviewDbContext _context;
        private readonly ICacheService _cacheService;

        public RateCalculaterNotificationHandler(IInterviewDbContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public async Task Handle(RateCalculaterNotification notification, CancellationToken cancellationToken)
        {
            var entity = await _context.Jobs.FirstOrDefaultAsync(c => c.ID == notification.JobId);
            short rate = 0;

            if (entity.WorkType != null)
            {
                if (entity.WorkType.Any())
                {
                    rate++;
                }
            }

            if (entity.Salary.HasValue)
            {
                rate++;
            }

            if (entity.FringeBenefit != null)
            {
                if (entity.FringeBenefit.Any())
                {
                    rate++;
                }
            }

            var badVocables = await _cacheService.GetAsync<List<string>>("BadVocables");

            if (badVocables.Any(c => !c.Contains(entity.Description)))
            {
                rate += 2;
            }

            entity.Rate = rate;
            _context.Jobs.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
