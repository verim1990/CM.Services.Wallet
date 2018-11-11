using CM.Services.Wallet.Contract.Application.Events.Integration;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Views.Concrete.Application.EventListeners.Integration
{
    public class UserDeletedIntegrationEventHandler : IRequestHandler<UserDeletedIntegrationEvent>
    {
        public UserDeletedIntegrationEventHandler()
        {
        }

        public async Task<Unit> Handle(UserDeletedIntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return Unit.Value;
        }
    }
}