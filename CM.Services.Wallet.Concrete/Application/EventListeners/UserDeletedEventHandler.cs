using CM.Services.Wallet.Contract.Application.Events;
using CM.Shared.Kernel.Application.Bus;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Concrete.Application.EventListeners
{
    public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
    {
        public IBus Bus { get; set; }

        public UserDeletedEventHandler(IBus bus)
        {
            Bus = bus;
        }

        Task INotificationHandler<UserDeletedEvent>.Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
        {
            return Bus.PublishIntegrationEvents(notification.User, notification.Header);
        }
    }
}