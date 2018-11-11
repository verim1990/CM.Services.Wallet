using CM.Services.Wallet.Contract.Application.Events;
using CM.Shared.Kernel.Application.Bus;
using CM.Shared.Kernel.Others.Kafka;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Concrete.Application.EventListeners
{
    public class UserUpdatedEventHandler : INotificationHandler<UserUpdatedEvent>
    {
        public IBus Bus { get; set; }

        public UserUpdatedEventHandler(IBus bus)
        {
            Bus = bus;
        }

        Task INotificationHandler<UserUpdatedEvent>.Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Bus.PublishIntegrationEvents(notification.User, notification.Header);
        }
    }
}