using CM.Services.Wallet.Contract.Application.Events.Integration;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Concrete.Application.EventListeners.Integration
{
    public class UserCreatedIntegrationEventHandler : IRequestHandler<UserCreatedIntegrationEvent>
    {
        public UserCreatedIntegrationEventHandler()
        {
        }

        public async Task<Unit> Handle(UserCreatedIntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return Unit.Value;
        }
    }
}