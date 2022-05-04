using Interview.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Interview.Application.UseCases.BadVocables.Commands.CreateBadVocable
{
    public class CreatedBadVocableNotificationHandler : INotificationHandler<CreatedBadVocableNotification>
    {
        private readonly ICacheService _cacheService;
        private readonly IInterviewDbContext _context;

        public CreatedBadVocableNotificationHandler(ICacheService cacheService, IInterviewDbContext context)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public async Task Handle(CreatedBadVocableNotification notification, CancellationToken cancellationToken)
        {
            await _cacheService.RemoveAsync("BadVocables");
            var entities = await _context.BadVocables.ToListAsync(cancellationToken: cancellationToken);
            await _cacheService.AddAsync("BadVocables", entities.Select(c => c.Name).ToList());
        }
    }
}
