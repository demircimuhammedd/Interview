using MediatR;

namespace Interview.Application.UseCases.Jobs.Commands.RateCalculator
{
    public class RateCalculaterNotification : INotification
    {
        public Guid JobId { get; set; }
    }
}
