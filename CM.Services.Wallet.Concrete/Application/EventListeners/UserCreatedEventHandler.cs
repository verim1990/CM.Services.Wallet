using CM.Services.Wallet.Contract.Application.Events;
using CM.Shared.Kernel.Application.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Concrete.Application.EventListeners
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        public IBus Bus { get; set; }

        public UserCreatedEventHandler(IBus bus)
        {
            Bus = bus;
        }

        Task INotificationHandler<UserCreatedEvent>.Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Bus.PublishIntegrationEvents(notification.User, notification.Header);
        }
    }
}